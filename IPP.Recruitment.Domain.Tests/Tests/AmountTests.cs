using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IPP.Recruitment.Domain.BusinessRules;

namespace IPP.Recruitment.Domain.Tests
{
    [TestClass]
    public class AmountTests
    {
        [TestInitialize]
        public void Setup()
        {
        }

        [TestMethod]
        public void TestPaymentAmountMin()
        {
            IsValidPaymentAmount _isValidPaymentAmount = new IsValidPaymentAmount(99);
            //Assert.IsTrue(myCollection.All(a => a > min && a < max));
            Assert.AreEqual(true, _isValidPaymentAmount.Validate(), "Accepts min amount");
        }
        [TestMethod]
        public void TestPaymentAmountMax()
        {
            IsValidPaymentAmount _isValidPaymentAmount = new IsValidPaymentAmount(99999999);
            Assert.AreEqual(true, _isValidPaymentAmount.Validate(), "Accepts max amount");
        }
        [TestMethod]
        public void TestPaymentAmountInvalidZero()
        {
            IsValidPaymentAmount _isValidPaymentAmount = new IsValidPaymentAmount(0);
            Assert.AreEqual(false, _isValidPaymentAmount.Validate(), "Rejects zero amount");
        }
        [TestMethod]
        public void TestPaymentAmountInvalidGreater()
        {
            IsValidPaymentAmount _isValidPaymentAmount = new IsValidPaymentAmount(100000000);
            Assert.AreEqual(false, _isValidPaymentAmount.Validate(), "Rejects the amount greater than max");
        }

        [TestMethod]
        public void TestPaymentAmountInvalidSmaller()
        {
            IsValidPaymentAmount _isValidPaymentAmount = new IsValidPaymentAmount(98);
            Assert.AreEqual(false, _isValidPaymentAmount.Validate(), "Rejects the amount smaller than min");
        }

    }
}
