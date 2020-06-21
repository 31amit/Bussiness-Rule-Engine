namespace Business_Rules_Engine.services
{
	using Customer = Business_Rules_Engine.domain.Customer;
	using Membership = Business_Rules_Engine.domain.Membership;

	public interface NotificationService
	{
		void notify(Customer customer, Membership membership);
	}

}