namespace Business_Rules_Engine.paymenthandlers
{
	using Customer = Business_Rules_Engine.domain.Customer;
	using LineItem = Business_Rules_Engine.domain.LineItem;
	using Membership = Business_Rules_Engine.domain.Membership;
	using Order = Business_Rules_Engine.domain.Order;
	using Payment = Business_Rules_Engine.domain.Payment;
	using ProductCategory = Business_Rules_Engine.domain.ProductCategory;
	using MembershipRepository = Business_Rules_Engine.repositories.MembershipRepository;
	using NotificationService = Business_Rules_Engine.services.NotificationService;

	// If the payment is for a membership, activate that membership.
	// If the payment is for a membership or upgrade, e-mail the owner and inform them of the activation/upgrade.
	public class MembershipActivateHandler : PaymentHandler
	{
		private readonly MembershipRepository _service;
		private readonly NotificationService _notificationService;

		public MembershipActivateHandler(MembershipRepository service, NotificationService notificationService)
		{
			_service = service;
			_notificationService = notificationService;
		}

		public virtual void run(Payment payment)
		{
			Order order = payment.Order;
			LineItem[] lineItems = order.LineItems;
			Customer customer = order.Customer;
			foreach (LineItem lineItem in lineItems)
			{
				if (!lineItem.hasCategory(ProductCategory.Membership))
				{
					continue;
				}

				Membership membership = _service.findBySku(lineItem.Sku);
				if (membership != null)
				{
					customer.addMembership(membership, _notificationService);
				}
			}
		}

	}
}