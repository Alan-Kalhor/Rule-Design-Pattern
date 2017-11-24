using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IPP.Recruitment.Domain.BusinessRules;

namespace IPP.Recruitment.Domain.Tests
{
    [TestClass]
    public class PaymentTests
    {
        [TestInitialize]
        public void Setup()
        {

        }

        [TestMethod]
        public void TestWhatsYourId()
        {
            PaymentService _paymentService = new PaymentService();
            Assert.AreEqual("008ab27c-36b2-43e5-91d5-edbd1e5b564b", _paymentService.WhatsYourId(), "Returns ID by WhatsYourId");
        }

        [TestMethod]
        public void TestMakePaymentValid()
        {
            CreditCard _creditCard = new CreditCard()
            {
                CardNumber = "5555555555554444",
                ExpiryYear = DateTime.Now.Year,
                ExpiryMonth = DateTime.Now.Month + 1,
                Amount = 100
            };
            PaymentService _paymentService = new PaymentService();
            Guid? guid = _paymentService.MakePayment(_creditCard);
            Guid guidOutput;
            Assert.AreEqual(true, Guid.TryParse(guid.ToString(), out guidOutput),"Returns GUID if payment is succeed");
        }
        [TestMethod]
        public void TestMakePaymentInvalidCardNo()
        {
            CreditCard _creditCard = new CreditCard()
            {
                CardNumber = "5555",
                ExpiryYear = DateTime.Now.Year,
                ExpiryMonth = DateTime.Now.Month+1,
                Amount = 100
            };
            PaymentService _paymentService = new PaymentService();
            Guid? guid = _paymentService.MakePayment(_creditCard);
            Assert.IsNull(guid, "Returns null if payment fails with invalid card number");
        }
        [TestMethod]
        public void TestMakePaymentEmptyCardNo()
        {
            CreditCard _creditCard = new CreditCard()
            {
                CardNumber = null,
                ExpiryYear = DateTime.Now.Year,
                ExpiryMonth = DateTime.Now.Month + 1,
                Amount = 100
            };
            PaymentService _paymentService = new PaymentService();
            Guid? guid = _paymentService.MakePayment(_creditCard);
            Assert.IsNull(guid, "Returns null if payment fails with invalid card number");
        }

        [TestMethod]
        public void TestMakePaymentInvalidZeroAmount()
        {
            CreditCard _creditCard = new CreditCard()
            {
                CardNumber = "5555555555554444",
                ExpiryYear = DateTime.Now.Year,
                ExpiryMonth = DateTime.Now.Month + 1,
                Amount = 0
            };
            PaymentService _paymentService = new PaymentService();
            Guid? guid = _paymentService.MakePayment(_creditCard);
            Assert.IsNull(guid, "Returns null if payment fails with invalid amount (zero)");
        }
        [TestMethod]
        public void TestMakePaymentInvalidExpiryYear()
        {
            CreditCard _creditCard = new CreditCard()
            {
                CardNumber = "5555555555554444",
                ExpiryYear = DateTime.Now.Year-1,
                ExpiryMonth = DateTime.Now.Month,
                Amount = 0
            };
            PaymentService _paymentService = new PaymentService();
            Guid? guid = _paymentService.MakePayment(_creditCard);
            Assert.IsNull(guid, "Returns null if payment fails with invalid amount (zero)");
        }

        [TestMethod]
        public void TestMakePaymentInvalidExpiryMonth()
        {
            CreditCard _creditCard = new CreditCard()
            {
                CardNumber = "5555555555554444",
                ExpiryYear = DateTime.Now.Year,
                ExpiryMonth = DateTime.Now.Month-1,
                Amount = 0
            };
            PaymentService _paymentService = new PaymentService();
            Guid? guid = _paymentService.MakePayment(_creditCard);
            Assert.IsNull(guid, "Returns null if payment fails with invalid amount (zero)");
        }

    }
}
