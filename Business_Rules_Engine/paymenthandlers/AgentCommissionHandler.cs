namespace Business_Rules_Engine.paymenthandlers
{
	using Agent = Business_Rules_Engine.domain.Agent;
	using LineItem = Business_Rules_Engine.domain.LineItem;
	using Order = Business_Rules_Engine.domain.Order;
	using Payment = Business_Rules_Engine.domain.Payment;
	using ProductCategory = Business_Rules_Engine.domain.ProductCategory;

	// If the payment is for a physical product or a book, generate a commission payment to the agent.
	public class AgentCommissionHandler : PaymentHandler
	{

		public virtual void run(Payment payment)
		{
			Order order = payment.Order;
			LineItem[] lineItems = order.LineItems;

			bool? addCommission = false;

			foreach (LineItem lineItem in lineItems)
			{
				if (lineItem.hasCategory(ProductCategory.Books) || lineItem.hasCategory(ProductCategory.Physical))
				{
					addCommission = true;
					break;
				}
			}

			if (addCommission.Value)
			{
				Agent agent = order.Agent;
				agent.generateCommission(order);
			}
		}

	}
}