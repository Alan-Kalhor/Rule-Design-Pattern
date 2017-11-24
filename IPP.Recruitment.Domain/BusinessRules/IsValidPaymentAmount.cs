namespace IPP.Recruitment.Domain.BusinessRules
{
    public class IsValidPaymentAmount : IBusinessRule
    {
        /// <summary>
		/// Checks if the amount represents a valid payment amount 
		/// </summary>
		/// <param name="amount">An amount value in cents (1 Dollar = 100 cents)</param>
		/// <remarks>
		/// Validation:
		/// The amount must be between 99 cents and 99999999 cents
		/// </remarks>
        private readonly long _amount;
        private static readonly log4net.ILog mylog =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public IsValidPaymentAmount(long amount)
        {
            _amount = amount;
        }
        public bool Validate()
        {
            bool _result = false;
            try
            {
                _result = ((_amount >= 99) && (_amount <= 99999999));
            }
            catch (System.Exception ex)
            {
                mylog.Error(ex);
            }
            return _result;
        }
    }
}