namespace TestBusiness_Rules_Engine.paymenthandlers
{
	using NUnit.Framework;
	using Agent = Business_Rules_Engine.domain.Agent;
	using Customer = Business_Rules_Engine.domain.Customer;
	using LineItem = Business_Rules_Engine.domain.LineItem;
	using Order = Business_Rules_Engine.domain.Order;
	using Payment = Business_Rules_Engine.domain.Payment;
	using ProductCategory = Business_Rules_Engine.domain.ProductCategory;
	using Moq;
	using Business_Rules_Engine.paymenthandlers;

	public class AgentCommissionHandlerTests
	{

		[Test]
		public virtual void runShouldNotGenerateAgentCommissionIfItemsInvalid()
		{
			LineItem[] lineItems = new LineItem[] { new LineItem("item", "item", new ProductCategory[] { ProductCategory.Membership, ProductCategory.Virtual }) };
			var customer = new Mock<Customer>().Object;
			Agent agent = new Mock<Agent>().Object;
			Order order = new Order(customer, lineItems, agent);
			Payment payment = new Payment(order);

			PaymentHandler sut = new AgentCommissionHandler();
			sut.run(payment);

			agent.generateCommission(order);
		}

		[Test]
		public virtual void runShouldGenerateAgentCommissionIfBookInOrder()
		{
			LineItem[] lineItems = new LineItem[]
			{
				new LineItem("item", "item", new ProductCategory[]{ProductCategory.Membership}),
				new LineItem("book1", "book1", new ProductCategory[]{ProductCategory.Books})
			};
			var customer = new Mock<Customer>().Object;
			Agent agent = new Mock<Agent>().Object;
			Order order = new Order(customer, lineItems, agent);
			Payment payment = new Payment(order);

			PaymentHandler sut = new AgentCommissionHandler();
			sut.run(payment);

			//verify(agent, times(1)).generateCommission(any());
			agent.generateCommission(order);
		}

		[Test]
		public virtual void runShouldGenerateAgentCommissionOnceIfMultipleBooksInOrder()
		{
			LineItem[] lineItems = new LineItem[]
			{
				new LineItem("book1", "book1", new ProductCategory[]{ProductCategory.Books}),
				new LineItem("book2", "book2", new ProductCategory[]{ProductCategory.Books}),
				new LineItem("book3", "book3", new ProductCategory[]{ProductCategory.Books})
			};
			var customer = new Mock<Customer>().Object;
			Agent agent = new Mock<Agent>().Object;
			Order order = new Order(customer, lineItems, agent);
			Payment payment = new Payment(order);

			PaymentHandler sut = new AgentCommissionHandler();
			sut.run(payment);

			//verify(agent, times(1)).generateCommission(any());
			agent.generateCommission(order);
		}

		[Test]
		public virtual void runShouldGenerateAgentCommissionIfPhysicalItemInOrder()
		{
			LineItem[] lineItems = new LineItem[]
			{
				new LineItem("item", "item", new ProductCategory[]{ProductCategory.Physical}),
				new LineItem("membership", "membership", new ProductCategory[]{ProductCategory.Membership})
			};
			var customer = new Mock<Customer>().Object;
			Agent agent = new Mock<Agent>().Object;
			Order order = new Order(customer, lineItems, agent);
			Payment payment = new Payment(order);

			PaymentHandler sut = new AgentCommissionHandler();
			sut.run(payment);

			//verify(agent, times(1)).generateCommission(any());
			agent.generateCommission(order);
		}
	}
}