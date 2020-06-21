using System.Collections.Generic;

namespace Business_Rules_Engine.domain
{

	public class LineItem
	{
		public LineItem(string sku, string name, ProductCategory[] categories)
		{
			_sku = sku;
			_name = name;

			_categories = new Dictionary<string, ProductCategory>();
			 if (categories != null)
			 {
				 foreach (ProductCategory cat in categories)
				 {
					 if (!_categories.ContainsKey(cat.Name))
					 {
						_categories[cat.Name] = cat;
					 }
				 }
			 }
		}

		private readonly string _sku;
		public virtual string Sku
		{
			get
			{
				return _sku;
			}
		}

		public readonly string _name;
		public virtual string Name
		{
			get
			{
				return _name;
			}
		}

		private readonly Dictionary<string, ProductCategory> _categories;
		public virtual bool hasCategory(ProductCategory category)
		{
			return _categories.ContainsKey(category.Name);
		}
	}
}