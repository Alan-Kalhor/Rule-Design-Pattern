using System;
using System.Globalization;
namespace IPP.Recruitment.Domain.BusinessRules
{
    public class IsValidExpiryDate : IBusinessRule
    {
        private readonly int _expiryMonth;
        private readonly int _expiryYear;
        private static readonly log4net.ILog mylog =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public IsValidExpiryDate(int expiryYear, int expiryMonth)
        {          
            _expiryYear = expiryYear;
            _expiryMonth = expiryMonth;
        }
        public bool Validate()
        {
            bool _result = false;
            try
            {
                _result = (_expiryYear.ToString().Length == 4) &&
                        (_expiryYear >= DateTime.Now.Year) &&
                        (_expiryMonth >= 1) && (_expiryMonth <= 12) &&
                        ((new DateTime(_expiryYear, _expiryMonth, 1)).CompareTo(DateTime.Now) > 0);

            }
            catch (Exception ex)
            {
                mylog.Error(ex);
            }
            return _result;
        }
    }
}