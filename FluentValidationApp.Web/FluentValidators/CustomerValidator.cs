﻿using FluentValidation;
using FluentValidationApp.Web.Models;

namespace FluentValidationApp.Web.FluentValidators
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name alanı boş olamaz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş olamaz").EmailAddress().WithMessage("Email alanı doğru formatta olmalıdır");
            RuleFor(x => x.Age).NotEmpty().WithMessage("Age alanı boş olamaaz").InclusiveBetween(18, 60).WithMessage("Age alanı 18 ile 60 arasında olmalıdır.");

        }
    }
}
