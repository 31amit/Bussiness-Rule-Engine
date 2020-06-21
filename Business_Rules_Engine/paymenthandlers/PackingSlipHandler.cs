namespace Business_Rules_Engine.paymenthandlers
{
	using LineItem = Business_Rules_Engine.domain.LineItem;
	using Order = Business_Rules_Engine.domain.Order;
	using Payment = Business_Rules_Engine.domain.Payment;
	using ProductCategory = Business_Rules_Engine.domain.ProductCategory;
	using PackingSlipService = Business_Rules_Engine.services.PackingSlipService;
	using RoyaltyService = Business_Rules_Engine.services.RoyaltyService;
	using ShippingService = Business_Rules_Engine.services.ShippingService;

	// If the payment is for a physical product, generate a packing slip for shipping.
	// If the payment is for a book, create a duplicate packing slip for the royalty department.
	// if the payment is for the video "Learning to Ski," add a free "First Aid" video to the packing slip
	public class PackingSlipHandler : PaymentHandler
	{
		private readonly PackingSlipService _packingSlipService;
		private readonly ShippingService _shippingService;
		private readonly RoyaltyService _royaltyService;

		public PackingSlipHandler(ShippingService shippingService, RoyaltyService royaltyService, PackingSlipService packingSlipService)
		{
			_shippingService = shippingService;
			_royaltyService = royaltyService;
			_packingSlipService = packingSlipService;
		}

		public virtual void run(Payment payment)
		{
			Order order = payment.Order;
			LineItem[] lineItems = order.LineItems;

			bool? generateForShipping = false;
			bool? generateForRoyalty = false;

			foreach (LineItem lineItem in lineItems)
			{
				if (lineItem.hasCategory(ProductCategory.Physical))
				{
					generateForShipping = true;
				}
				if (lineItem.hasCategory(ProductCategory.Books))
				{
					generateForRoyalty = true;
				}

				if (lineItem.Sku == "learning-to-ski")
				{
					order.addGiftBySku("first-aid");
				}
			}

			_packingSlipService.generate(order);

			if (generateForShipping.Value)
			{
				_shippingService.generatePackingSlip(order);
			}
			if (generateForRoyalty.Value)
			{
				_royaltyService.generatePackingSlip(order);
			}
		}
	}

}