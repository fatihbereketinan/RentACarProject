using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("Lütfen isim giriniz");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Lütfen soyisim giriniz");
            RuleFor(u => u.Email).NotEmpty().WithMessage("Lütfen email giriniz");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Lütfen parola giriniz");
        }
    }
}
