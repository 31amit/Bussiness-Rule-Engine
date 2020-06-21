using System.Collections.Generic;
using System.Linq;

namespace Business_Rules_Engine.domain
{

	public class Order
	{
		public Order(Customer customer, LineItem[] lineItems, Agent agent)
		{
			if (lineItems == null || lineItems.Length == 0)
			{
				throw new System.ArgumentException("line items are required");
			}
			_lineItems = lineItems;

			_customer = customer;
			_agent = agent;

			_giftSkus = new HashSet<string>();
		}

		private readonly Customer _customer;
		public virtual Customer Customer
		{
			get
			{
				return _customer;
			}
		}

		private readonly LineItem[] _lineItems;
		public virtual LineItem[] LineItems
		{
			get
			{
				return _lineItems;
			}
		}

		private readonly Agent _agent;
		public virtual Agent Agent
		{
			get
			{
				return _agent;
			}
		}

		private HashSet<string> _giftSkus;
		public virtual void addGiftBySku(string sku)
		{
			if (!_giftSkus.Contains(sku))
			{
				_giftSkus.Add(sku);
			}
		}

		public virtual string[] GiftSkus
		{
			get
			{
				return _giftSkus.ToArray();
			}
		}
	}
}