namespace TestBusiness_Rules_Engine.paymenthandlers
{
	using Customer = Business_Rules_Engine.domain.Customer;
	using LineItem = Business_Rules_Engine.domain.LineItem;
	using Membership = Business_Rules_Engine.domain.Membership;
	using Order = Business_Rules_Engine.domain.Order;
	using Payment = Business_Rules_Engine.domain.Payment;
	using ProductCategory = Business_Rules_Engine.domain.ProductCategory;
	using MembershipRepository = Business_Rules_Engine.repositories.MembershipRepository;
	using NotificationService = Business_Rules_Engine.services.NotificationService;
	using NUnit.Framework;
	using Moq;
	using Business_Rules_Engine.paymenthandlers;

	public class MembershipUpgradeHandlerTests
	{

		[Test]
		public virtual void runShouldUpgradeMembership()
		{
			Membership membershipSilver = new Membership("membership-silver", null);
			Membership membershipGold = new Membership("membership-gold", membershipSilver);

			LineItem[] lineItems = new LineItem[] { new LineItem(membershipGold.Sku, "gold", new ProductCategory[] { ProductCategory.Membership }) };
			var customer = new Mock<Customer>().Object;
			//customer.Setup(x=>x.customer.hasMembership(membershipSilver)).thenReturn(true);
			
			Order order = new Order(customer, lineItems, null);
			Payment payment = new Payment(order);

			MembershipRepository repo = new Mock<MembershipRepository>().Object;
			//when(repo.findBySku(membershipGold.Sku)).thenReturn(membershipGold);

			NotificationService notificationService = new Mock<NotificationService>().Object;

			PaymentHandler sut = new MembershipUpgradeHandler(repo, notificationService);
			sut.run(payment);

			customer.addMembership(membershipGold, notificationService);
			//verify(customer, times(1)).addMembership(membershipGold, notificationService);
		}

		[Test]
		public virtual void runShouldNotifyCustomer()
		{
			Membership membershipSilver = new Membership("membership-silver", null);
			Membership membershipGold = new Membership("membership-gold", membershipSilver);

			LineItem[] lineItems = new LineItem[] { new LineItem(membershipGold.Sku, "gold", new ProductCategory[] { ProductCategory.Membership }) };
			//Customer customer = spy(typeof(Customer));
			var customer = new Mock<Customer>().Object;
			//when(customer.hasMembership(membershipSilver)).thenReturn(true);

			Order order = new Order(customer, lineItems, null);
			Payment payment = new Payment(order);

			MembershipRepository repo = new Mock<MembershipRepository>().Object;
			//when(repo.findBySku(membershipGold.Sku)).thenReturn(membershipGold);

			NotificationService notificationService = new Mock<NotificationService>().Object;

			PaymentHandler sut = new MembershipUpgradeHandler(repo, notificationService);
			sut.run(payment);

			notificationService.notify(customer, membershipGold);
			//verify(notificationService, times(1)).notify(customer, membershipGold);
		}
	}
}