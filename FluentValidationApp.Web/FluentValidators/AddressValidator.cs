using FluentValidation;
using FluentValidationApp.Web.Models;

namespace FluentValidationApp.Web.FluentValidators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        private string notEmptyMessage = "{PropertyName} alanı boş olamaz";
        
        public AddressValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage(notEmptyMessage);

            RuleFor(x => x.Province)
                .NotEmpty().WithMessage(notEmptyMessage);

            RuleFor(x => x.PostCode)
                .NotEmpty().WithMessage(notEmptyMessage)
                .MaximumLength(5).WithMessage("{PropertyName} alanı en fazla {MaxLength} karakter içerebilir");



        }
    }
}
