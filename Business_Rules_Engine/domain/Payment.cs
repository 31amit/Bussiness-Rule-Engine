namespace Business_Rules_Engine.domain
{
	using PaymentHandler = Business_Rules_Engine.paymenthandlers.PaymentHandler;

	public class Payment
	{

		public Payment(Order order)
		{
			_order = order;
		}

		private readonly Order _order;
		public virtual Order Order
		{
			get
			{
				return _order;
			}
		}

		public virtual void Process(PaymentHandler[] rules)
		{
			foreach (PaymentHandler rule in rules)
			{
				rule.run(this);
			}
		}
	}
}