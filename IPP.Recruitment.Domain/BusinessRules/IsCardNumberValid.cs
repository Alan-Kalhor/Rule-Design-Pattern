namespace IPP.Recruitment.Domain.BusinessRules
{
    /// <summary>
    /// Performs a Mod-10/LUHN check on the passed number and returns true if the check passed
    /// </summary>
    /// <param name="cardNumber">A 16 digit card number</param>
    /// <returns>true if the card number is valid, otherwise false</returns>
    /// <remarks>
    /// Refer here for MOD10 algorithm: https://en.wikipedia.org/wiki/Luhn_algorithm
    /// </remarks>
    public class IsCardNumberValid : IBusinessRule
    {
        private readonly string _cardNumber;
        private static readonly log4net.ILog mylog =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public IsCardNumberValid(string cardNumber)
        {
            _cardNumber = cardNumber;
        }

        public bool Validate()
        {
            bool _result = false;
            try
            {
                _result = (_cardNumber.Length == 16) &&
                        (Common.Utilities.Mod10Check(_cardNumber));
            }
            catch (System.Exception ex)
            {
                mylog.Error(ex);
            }
            return _result;
        }
    }
}