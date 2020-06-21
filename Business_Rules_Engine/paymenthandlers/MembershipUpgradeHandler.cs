namespace Business_Rules_Engine.paymenthandlers
{
	using Payment = Business_Rules_Engine.domain.Payment;
	using Order = Business_Rules_Engine.domain.Order;
	using Customer = Business_Rules_Engine.domain.Customer;
	using LineItem = Business_Rules_Engine.domain.LineItem;
	using Membership = Business_Rules_Engine.domain.Membership;
	using ProductCategory = Business_Rules_Engine.domain.ProductCategory;
	using MembershipRepository = Business_Rules_Engine.repositories.MembershipRepository;
	using NotificationService = Business_Rules_Engine.services.NotificationService;

	// If the payment is an upgrade to a membership, apply the upgrade.
	// If the payment is for a membership or upgrade, e-mail the owner and inform them of the activation/upgrade.
	public class MembershipUpgradeHandler : PaymentHandler
	{

		private readonly MembershipRepository _repo;
		private readonly NotificationService _notificationService;

		public MembershipUpgradeHandler(MembershipRepository repo, NotificationService notificationService)
		{
			_repo = repo;
			_notificationService = notificationService;
		}

		public virtual void run(Payment payment)
		{
			Order order = payment.Order;
			Customer customer = order.Customer;
			LineItem[] lineItems = order.LineItems;
			foreach (LineItem lineItem in lineItems)
			{
				if (!lineItem.hasCategory(ProductCategory.Membership))
				{
					continue;
				}

				Membership membership = _repo.findBySku(lineItem.Sku);
				Membership previousLevel = membership.PreviousLevel;
				if (customer.hasMembership(previousLevel))
				{
					customer.addMembership(membership, _notificationService);
				}
			}
		}
	}
}