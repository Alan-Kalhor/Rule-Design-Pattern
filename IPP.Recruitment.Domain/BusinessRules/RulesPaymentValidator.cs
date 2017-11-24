using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPP.Recruitment.Domain.BusinessRules
{
    class RulesPaymentValidator : IRulesPaymentValidator
    {
        List<IBusinessRule> _rules = new List<IBusinessRule>();
        private static readonly log4net.ILog mylog =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public RulesPaymentValidator(CreditCard creditCard)
        {
            _rules.Add(new CanMakePaymentWithCard(creditCard.CardNumber, creditCard.ExpiryMonth, creditCard.ExpiryYear));
            _rules.Add(new IsValidPaymentAmount(creditCard.Amount));

        }
        //private static Type[] GetAllBussinesRules()
        //{

        //    var q = from t in Assembly.GetExecutingAssembly().GetTypes()
        //            where t.IsClass && t.Namespace == "IPP.Recruitment.Domain.BusinessRules" && typeof(BusinessRules.IBusinessRule).IsAssignableFrom(t)
        //            select t;

        //    return q.ToArray();

        //}

        public bool ValidatePayment(CreditCard creditCard)
        {
            bool _result = false;
            try
            {
                foreach (var rule in _rules)
                {
                    if (!(rule as IBusinessRule).Validate()) 
                        return false;
                }
                _result = true;

            }
            catch (Exception ex)
            {
                mylog.Error(ex);
            }
            return _result;

        }

    }
}
