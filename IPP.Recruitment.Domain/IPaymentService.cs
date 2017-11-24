using System;
using System.ServiceModel;

namespace IPP.Recruitment.Domain
{
    /// <summary>
	/// The contract required to be implemented by a payment service
	/// </summary>
    [ServiceContract]
    public interface IPaymentService
    {
        /// <summary>
		/// Returns the unique ID allocated to a candidate
		/// </summary>
        [OperationContract]
        string WhatsYourId();

        /// <summary>
		/// Returns the GUID allocated to payment
		/// </summary>
        [OperationContract]
        Guid? MakePayment(CreditCard creditCard);
    }
}