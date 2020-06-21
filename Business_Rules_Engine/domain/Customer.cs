namespace Business_Rules_Engine.domain
{
	using NotificationService = Business_Rules_Engine.services.NotificationService;

	// fake empty class, behaviour is mocked in the tests 
	public class Customer
	{
	   public virtual void addMembership(Membership membership, NotificationService notificationService)
	   {
		  // notifications should happen via Domain Events,
		  // this is just a quick hack.
		  notificationService.notify(this, membership);
	   }

	   public virtual bool hasMembership(Membership membership)
	   {
		  return false;
	   }
	}

}