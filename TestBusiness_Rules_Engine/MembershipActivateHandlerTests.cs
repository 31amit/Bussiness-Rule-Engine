namespace TestBusiness_Rules_Engine.paymenthandlers
{
	using LineItem = Business_Rules_Engine.domain.LineItem;
	using Membership = Business_Rules_Engine.domain.Membership;
	using Order = Business_Rules_Engine.domain.Order;
	using Customer = Business_Rules_Engine.domain.Customer;
	using Payment = Business_Rules_Engine.domain.Payment;
	using ProductCategory = Business_Rules_Engine.domain.ProductCategory;
	using MembershipRepository = Business_Rules_Engine.repositories.MembershipRepository;
	using NotificationService = Business_Rules_Engine.services.NotificationService;
	using NUnit.Framework;
	using Moq;
	using Business_Rules_Engine.paymenthandlers;

	public class MembershipActivateHandlerTests
	{
		[Test]
		public virtual void runShouldDoNothingIfNoMembershipsInOrder()
		{
			LineItem[] lineItems = new LineItem[] { new LineItem("item1", "item1", new ProductCategory[] { ProductCategory.Physical }) };
			var customer = new Mock<Customer>().Object;
			Order order = new Order(customer, lineItems, null);
			Payment payment = new Payment(order);

			MembershipRepository service = new Mock<MembershipRepository>().Object;
			NotificationService notificationService = new Mock<NotificationService>().Object;
			Membership membership = new Membership("item1", null);
			PaymentHandler sut = new MembershipActivateHandler(service, notificationService);
			sut.run(payment);

			customer.addMembership(membership, notificationService);
			
		}

		[Test]
		public virtual void runShouldActivateMembershipIfInOrder()
		{
			LineItem[] lineItems = new LineItem[] { new LineItem("item1", "item1", new ProductCategory[] { ProductCategory.Membership }) };
			var customer = new Mock<Customer>().Object;
			Order order = new Order(customer, lineItems, null);
			Payment payment = new Payment(order);

			MembershipRepository repo = new Mock<MembershipRepository>().Object;
			Membership membership = new Membership("item1", null);
			

			NotificationService notificationService = new Mock<NotificationService>().Object;

			PaymentHandler sut = new MembershipActivateHandler(repo, notificationService);
			sut.run(payment);

			customer.addMembership(membership, notificationService);
			
		}
		[Test]
		public virtual void runShouldNotifyCustomer()
		{
			LineItem[] lineItems = new LineItem[] { new LineItem("item1", "item1", new ProductCategory[] { ProductCategory.Membership }) };
			var customer = new Mock<Customer>().Object;
			Order order = new Order(customer, lineItems, null);
			Payment payment = new Payment(order);

			MembershipRepository repo = new Mock<MembershipRepository>().Object;
			Membership membership = new Membership("item1", null);
			//when(repo.findBySku("item1")).thenReturn(membership);

			NotificationService notificationService = new Mock<NotificationService>().Object;

			PaymentHandler sut = new MembershipActivateHandler(repo, notificationService);
			sut.run(payment);

			notificationService.notify(customer, membership);
			//verify(notificationService, times(1)).notify(customer, membership);
		}
	}
}
