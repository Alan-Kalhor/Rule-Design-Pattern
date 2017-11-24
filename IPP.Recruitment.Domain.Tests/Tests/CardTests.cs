using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IPP.Recruitment.Domain.BusinessRules;

namespace IPP.Recruitment.Domain.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestInitialize]
        public void Setup() 
        {
        }

        [TestMethod]
        public void TestCardExpirySameYearGreaterMonth()
        {          
            IsValidExpiryDate _isValidExpiryYear = new IsValidExpiryDate(DateTime.Now.Year, DateTime.Now.Month+1);
            Assert.AreEqual(true, _isValidExpiryYear.Validate(),"Accepts same year and greater month");
        }

        [TestMethod]
        public void TestCardExpiryGreaterYearSameMonth()
        {
            IsValidExpiryDate _isValidExpiryDate = new IsValidExpiryDate(DateTime.Now.Year+1, DateTime.Now.Month);
            Assert.AreEqual(true, _isValidExpiryDate.Validate(), "Accepts greater year and same month");
        }

        [TestMethod]
        public void TestCardExpiryTodaydate()
        {
            IsValidExpiryDate _isValidExpiryDate = new IsValidExpiryDate(DateTime.Now.Year, DateTime.Now.Month);
            Assert.AreEqual(false, _isValidExpiryDate.Validate(), "Rejects expiry date if it's today");
        }

        [TestMethod]
        public void TestCardExpiryPastDate()
        {
            IsValidExpiryDate _isValidExpiryDate = new IsValidExpiryDate(DateTime.Now.Year-1, DateTime.Now.Month);
            Assert.AreEqual(false, _isValidExpiryDate.Validate(),"Rejects past expiry date");
        }

        [TestMethod]
        public void TestCardExpiryInvalidYearZero()
        {
            IsValidExpiryDate _isValidExpiryDate = new IsValidExpiryDate(0, 0);
            Assert.AreEqual(false, _isValidExpiryDate.Validate(), "Rejects invalid expiry year zero");
        }
        [TestMethod]
        public void TestCardExpiryInvalidYearMinus()
        {
            IsValidExpiryDate _isValidExpiryDate = new IsValidExpiryDate(-1, -1);
            Assert.AreEqual(false, _isValidExpiryDate.Validate(), "Rejects invalid minus expiry year");
        }


        [TestMethod]
        public void TestCardNumberInvalidLengthGreater()
        {
            IsCardNumberValid _isCardNumberValid = new IsCardNumberValid("60379913915284232");
            Assert.AreEqual(false, _isCardNumberValid.Validate(),"Rejects card nulmer with invalid length");
        }

        [TestMethod]
        public void TestCardNumberInvalidLengthSmaller()
        {
            IsCardNumberValid _isCardNumberValid = new IsCardNumberValid("603799139152842");
            Assert.AreEqual(false, _isCardNumberValid.Validate(), "Rejects card nulmer with invalid length");
        }

        [TestMethod]
        public void TestCardNumberInvalid()
        {
            IsCardNumberValid _isCardNumberValid = new IsCardNumberValid("6037991391528422");
            Assert.AreEqual(false, _isCardNumberValid.Validate(), "Rejects invalid card nulmer ");
        }

        [TestMethod]
        public void TestCardNumbeNull()
        {
            IsCardNumberValid _isCardNumberValid = new IsCardNumberValid(null);
            Assert.AreEqual(false, _isCardNumberValid.Validate(), "Rejects null card nulmer");
        }

        [TestMethod]
        public void TestCardNumberValidVisa()
        {
            IsCardNumberValid _isCardNumberValid = new IsCardNumberValid("4012888888881881");
            Assert.AreEqual(true, _isCardNumberValid.Validate(), "Accepts sample visa card");
        }

        [TestMethod]
        public void TestCardNumberValidMaster()
        {
            IsCardNumberValid _isCardNumberValid = new IsCardNumberValid("5555555555554444");
            Assert.AreEqual(true, _isCardNumberValid.Validate(), "Accepts sample master card");
        }


    }
}
