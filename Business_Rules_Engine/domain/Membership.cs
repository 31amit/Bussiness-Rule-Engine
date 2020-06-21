namespace Business_Rules_Engine.domain
{
	public class Membership : Product
	{

		public Membership(string sku, Membership prev) : base(sku)
		{
			_previous = prev;
		}

		private Membership _previous;
		public virtual Membership PreviousLevel
		{
			get
			{
				return _previous;
			}
		}

	}

}