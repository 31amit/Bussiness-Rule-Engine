using System;

namespace Business_Rules_Engine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //If the payment is for a physical product, generate a packing slip for shipping.

            //If the payment is for a book, create a duplicate packing slip for the royalty department.

            //If the payment is for a membership, activate that membership.

            //If the payment is an upgrade to a membership, apply the upgrade.

            //If the payment is for a membership or upgrade, e - mail the owner and inform them of the activation / upgrade.

            //If the payment is for the video “Learning to Ski,” add a free “First Aid” video to the packing slip(the result of a court
            //decision in 1997).

            //If the payment is for a physical product or a book, generate a commission payment to the agent.
        }
    }

    //public interface IPaymentManager
    //{
    //    string generatePackingSlipForShipping();
    //    string createDuplicatePackingSlipForRoyaltyDepartment();
    //    string activateMembership();
    //    string applyUpgrade();
    //    string sendMailForActivationUpgrade();
    //    string addFirstAidVideo();
    //    string generateCommissionPaymentAgent();


    //}



    //public class Product
    //{
    //    private string _shippingAddress;
    //    private string _name;
    //    private readonly string _productCode;

    //    public Product(string name)
    //    {
    //        this._name = name;
    //        _productCode = Guid.NewGuid().ToString("N");
    //    }

    //    public void SetShippingAddress(string shippingAddress)
    //    {
    //        this._shippingAddress = shippingAddress;
    //    }

    //    public string GetShippingAddress()
    //    {
    //        return _shippingAddress;
    //    }

    //    public string GetProductCode()
    //    {
    //        return _productCode;
    //    }
    //}

    //public class Payment
    //{
    //    private readonly Product _physicalProduct;
    //    private decimal _amount;
    //    private IShippingSlipService _shippingSlipService;
    //    private string _shippingAddress;

    //    public Payment(Product physicalProduct, string shippingAddress)
    //    {
    //        if (physicalProduct == null) throw new ArgumentNullException("physicalProduct");
    //        if (shippingAddress == null) throw new ArgumentNullException("shippingAddress");

    //        this._physicalProduct = physicalProduct;
    //        this._shippingAddress = shippingAddress;
    //    }

    //    public virtual void CompletePayment(decimal amount)
    //    {
    //        _amount = amount;
    //        if (_physicalProduct != null) _shippingSlipService.GenerateShippingSlipForAddress(_physicalProduct.GetShippingAddress());
    //    }

    //    public void SetShippingService(IShippingSlipService shippingSlipService)
    //    {
    //        _shippingSlipService = shippingSlipService;
    //    }
    //}

    //public interface IShippingSlipService
    //{
    //    void GenerateShippingSlipForAddress(string shippingAddress);
    //}
}
