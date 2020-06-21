namespace Business_Rules_Engine.domain
{
	public class ProductCategory
	{

		private ProductCategory(string name)
		{
			_name = name;
		}

		public readonly string _name;
		public virtual string Name
		{
			get
			{
				return _name;
			}
		}

		public static readonly ProductCategory Books = new ProductCategory("books");
		public static readonly ProductCategory Physical = new ProductCategory("physical");
		public static readonly ProductCategory Virtual = new ProductCategory("virtual");
		public static readonly ProductCategory Membership = new ProductCategory("membership");
		public static readonly ProductCategory Videos = new ProductCategory("videos");
	}
}