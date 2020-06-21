namespace Business_Rules_Engine.paymenthandlers
{
	using Payment = Business_Rules_Engine.domain.Payment;

	public interface PaymentHandler
	{
		void run(Payment payment);
	}

}