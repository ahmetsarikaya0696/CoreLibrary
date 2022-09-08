using FluentValidation;
using FluentValidation.Validators;
using FluentValidationApp.Web.Models;

namespace FluentValidationApp.Web.FluentValidators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        private string notEmptyMessage = "{PropertyName} alanı boş olamaz";
        public CustomerValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(notEmptyMessage);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(notEmptyMessage)
                .EmailAddress().WithMessage("Geçerli bir {PropertyName} giriniz");

            RuleFor(x => x.Age)
                .NotEmpty().WithMessage(notEmptyMessage)
                .InclusiveBetween(18, 60).WithMessage("{PropertyName} alanı 18 - 60 arasında olmalıdır");

            RuleFor(x => x.Birthday)
                .NotEmpty().WithMessage(notEmptyMessage)
                .Must(x => DateTime.Now.AddYears(-18) >= x).WithMessage("En az 18 yaşında olmalısınız");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage(notEmptyMessage)
                .IsInEnum().WithMessage("Erkek=1 Kadın=2"); // Api için gerekli

            RuleFor(x => x.CreditCard.Number)
                .NotEmpty().WithMessage(notEmptyMessage)
                .Length(16).WithMessage("Number alanı 16 karakterden oluşmalıdır");

            RuleFor(x => x.CreditCard.ValidDate)
                .NotEmpty().WithMessage("ValidDate alanı boş olamaz")
                .GreaterThan(DateTime.Now).WithMessage("ValidDate ileri bir tarih olmalıdır");

            RuleForEach(x => x.Addresses).SetValidator(new AddressValidator());
        }
    }
}