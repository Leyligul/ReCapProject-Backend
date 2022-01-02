using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    internal class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.firstName).NotEmpty();
            RuleFor(p => p.lastName).NotEmpty();
            RuleFor(p => p.mail).NotEmpty();
        }
    }
}
