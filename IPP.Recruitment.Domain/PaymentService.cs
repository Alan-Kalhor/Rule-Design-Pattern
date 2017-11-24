using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPP.Recruitment.Domain
{
    public class PaymentService : IPaymentService
    {
        private IPP.Recruitment.Domain.BusinessRules.RulesPaymentValidator _rulesPaymentValidator;        
        public string WhatsYourId() 
        {
            return "008ab27c-36b2-43e5-91d5-edbd1e5b564b";
        }

        public Guid? MakePayment(CreditCard creditCard)
        {
            _rulesPaymentValidator = new BusinessRules.RulesPaymentValidator(creditCard);
            if (_rulesPaymentValidator.ValidatePayment(creditCard))
                return Guid.NewGuid();
            else
                return null;
        }


    }
}
