using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {

        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Pay(Card card)
        {
           return new SuccessResult(Messages.SuccessfulPayment);
           

        }




      
    }
}
