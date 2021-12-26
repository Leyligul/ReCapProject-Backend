using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class PaymentValidator:AbstractValidator<Card>
    {

        public PaymentValidator()
        {
            RuleFor(p=>p.nameOnCard).NotEmpty();
            RuleFor(p => p.cardNumber).Length(16);
            RuleFor(p => p.cvv).Length(3);
            RuleFor(p => p.validDate).NotEmpty();
        }
       
    }
}
