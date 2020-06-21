namespace Business_Rules_Engine.services
{
	using PackingSlip = Business_Rules_Engine.domain.PackingSlip;
	using Order = Business_Rules_Engine.domain.Order;

	public interface PackingSlipService
	{
		PackingSlip generate(Order order);
	}
}