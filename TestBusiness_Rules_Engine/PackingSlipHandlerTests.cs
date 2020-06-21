namespace TestBusiness_Rules_Engine.paymenthandlers
{
	using Customer = Business_Rules_Engine.domain.Customer;
	using LineItem = Business_Rules_Engine.domain.LineItem;
	using Order = Business_Rules_Engine.domain.Order;
	using Payment = Business_Rules_Engine.domain.Payment;
	using ProductCategory = Business_Rules_Engine.domain.ProductCategory;
	using PackingSlipService = Business_Rules_Engine.services.PackingSlipService;
	using RoyaltyService = Business_Rules_Engine.services.RoyaltyService;
	using ShippingService = Business_Rules_Engine.services.ShippingService;
	using NUnit.Framework;
	using Moq;
    using Business_Rules_Engine.paymenthandlers;

    public class PackingSlipHandlerTests
	{
		public PackingSlipHandlerTests()
		{
		}

		[Test]
		public virtual void runShouldNotGenerateForShippingWhenNoValidItemsAvailable()
		{
			LineItem[] lineItems = new LineItem[]
			{
				new LineItem("item1", "item1", new ProductCategory[]{ProductCategory.Membership}),
				new LineItem("item2", "item2", new ProductCategory[]{ProductCategory.Virtual})
			};

			var customer = new Mock<Customer>().Object;
		    //customer.Setup(x => x..hasMembership(Membership)).Returns(true);

			Order order = new Order(customer, lineItems, null);
			Payment payment = new Payment(order);

			PackingSlipService packingSlipService = new  Mock<PackingSlipService>().Object;
			ShippingService shippingService = new Mock<ShippingService>().Object;
			RoyaltyService royaltyService = new Mock<RoyaltyService>().Object;

			PaymentHandler sut = new PackingSlipHandler(shippingService, royaltyService, packingSlipService);
			sut.run(payment);

			var slip = shippingService.generatePackingSlip(order);
			Assert.AreEqual(slip,null);
		}


		[Test]
		public virtual void runShouldGenerateForShippingWhenPhysicalAvailable()
		{
			LineItem[] lineItems = new LineItem[]
			{
				new LineItem("item1", "item1", new ProductCategory[]{ProductCategory.Physical}),
				new LineItem("item2", "item2", new ProductCategory[]{ProductCategory.Membership})
			};
			var customer = new Mock<Customer>().Object;
			Order order = new Order(customer, lineItems, null);
			Payment payment = new Payment(order);

			PackingSlipService packingSlipService = new Mock<PackingSlipService>().Object;
			ShippingService shippingService = new Mock<ShippingService>().Object;
			RoyaltyService royaltyService = new Mock<RoyaltyService>().Object;

			PaymentHandler sut = new PackingSlipHandler(shippingService, royaltyService, packingSlipService);
			sut.run(payment);

			//verify(shippingService, times(1)).generatePackingSlip(order);
			var slip = shippingService.generatePackingSlip(order);
			Assert.AreEqual(slip, null);
		}


		[Test]
		public virtual void runShouldGenerateForRoyaltyWhenBooksAvailable()
		{
			LineItem[] lineItems = new LineItem[]
			{
				new LineItem("item1", "item1", new ProductCategory[]{ProductCategory.Books}),
				new LineItem("item2", "item2", new ProductCategory[]{ProductCategory.Membership})
			};
			var customer = new Mock<Customer>().Object;
			Order order = new Order(customer, lineItems, null);
			Payment payment = new Payment(order);

			PackingSlipService packingSlipService = new Mock<PackingSlipService>().Object;
			ShippingService shippingService = new Mock<ShippingService>().Object;
			RoyaltyService royaltyService = new Mock<RoyaltyService>().Object;

			PaymentHandler sut = new PackingSlipHandler(shippingService, royaltyService, packingSlipService);
			sut.run(payment);

			//verify(royaltyService, times(1)).generatePackingSlip(order);
			var slip = shippingService.generatePackingSlip(order);
			Assert.AreEqual(slip, null);
		}

		[Test]
		public virtual void runShouldAddFirstAidGiftWhenRequested()
		{
			LineItem[] lineItems = new LineItem[] { new LineItem("learning-to-ski", "Learning to Ski", new ProductCategory[] { ProductCategory.Videos }) };
			var customer = new Mock<Customer>().Object;
			Order order = new Order(customer, lineItems, null);
			Payment payment = new Payment(order);

			PackingSlipService packingSlipService = new Mock<PackingSlipService>().Object;
			ShippingService shippingService = new Mock<ShippingService>().Object;
			RoyaltyService royaltyService = new Mock<RoyaltyService>().Object;

			PaymentHandler sut = new PackingSlipHandler(shippingService, royaltyService, packingSlipService);
			sut.run(payment);

			string[] gifts = order.GiftSkus;
			Assert.IsNotNull(gifts);
			Assert.IsTrue(gifts.Length == 1);
			//Assert.IsTrue(Arrays.binarySearch(gifts, "first-aid") == 0);
		}


		[Test]
		public virtual void runShouldGeneratePackingSlip()
		{
			LineItem[] lineItems = new LineItem[] { new LineItem("item1", "item1", new ProductCategory[] { ProductCategory.Physical }) };
			var customer = new Mock<Customer>().Object;
			Order order = new Order(customer, lineItems, null);
			Payment payment = new Payment(order);

			PackingSlipService packingSlipService = new Mock<PackingSlipService>().Object;
			ShippingService shippingService = new Mock<ShippingService>().Object;
			RoyaltyService royaltyService = new Mock<RoyaltyService>().Object;

			PaymentHandler sut = new PackingSlipHandler(shippingService, royaltyService, packingSlipService);
			sut.run(payment);

			//verify(packingSlipService, times(1)).generate(order);
			var pack = packingSlipService.generate(order);
			Assert.AreEqual(pack, null);
		}
	}
}