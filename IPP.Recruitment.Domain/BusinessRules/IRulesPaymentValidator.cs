using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPP.Recruitment.Domain.BusinessRules
{
    interface IRulesPaymentValidator
    {
        bool ValidatePayment(CreditCard creditCard);
    }
}
