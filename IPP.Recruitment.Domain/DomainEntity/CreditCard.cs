namespace IPP.Recruitment.Domain
{
    public class CreditCard
    {
        /// <summary>
		/// A 16 digit card number
		/// </summary>
        public string CardNumber { get; set; }
        /// <summary>
		/// Represents payment amount between 99 cents and 99999999 cents
		/// </summary>
        public long Amount { get; set; }
        /// <summary>
		/// Credit expiry month 1 or 2 digits 
		/// </summary>
        public int ExpiryMonth { get; set; }
        /// <summary>
		/// Credit expiry year 4 digits
		/// </summary>
        public int ExpiryYear { get; set; }
    }
}