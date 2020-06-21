namespace Business_Rules_Engine.repositories
{
	using Membership = Business_Rules_Engine.domain.Membership;

	public interface MembershipRepository
	{
		Membership findBySku(string sku);
	}
}