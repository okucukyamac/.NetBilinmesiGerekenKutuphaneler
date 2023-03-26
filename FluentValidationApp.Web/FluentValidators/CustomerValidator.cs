using FluentValidation;
using FluentValidationApp.Web.Models;
using System;

namespace FluentValidationApp.Web.FluentValidators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} alanı boş olamaz";

        public CustomerValidator()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage).EmailAddress().WithMessage("Email alanı doğru formatta olmalıdır");
            RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmptyMessage).InclusiveBetween(18, 60).WithMessage("Age alanı 18 ile 60 arasında olmalıdır.");


            RuleFor(a => a.BirthDay).NotEmpty().WithMessage(NotEmptyMessage).Must(a =>
            {
                return DateTime.Now.AddYears(-18) >= a;
            }).WithMessage("Yaşınız 18'den büyük olmalıdır.");

            RuleForEach(a=>a.Addresses).SetValidator(new AddressValidator());
        }
    }
}
