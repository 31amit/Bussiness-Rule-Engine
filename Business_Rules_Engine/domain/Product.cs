namespace Business_Rules_Engine.domain
{
	public class Product
	{
		public Product(string sku)
		{
			_sku = sku;
		}

		private string _sku;
		public virtual string Sku
		{
			get
			{
				return _sku;
			}
		}
	}
}