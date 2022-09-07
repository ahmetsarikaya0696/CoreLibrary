using FluentValidation;
using FluentValidationApp.Web.DTOs;

namespace FluentValidationApp.Web.FluentValidators
{
    public class EventDateDtoValidator : AbstractValidator<EventDateDto>
    {
        private string notEmptyMessage = "{PropertyName} alanı boş olamaz";

        public EventDateDtoValidator()
        {
            RuleFor(x => x.Year)
                .NotEmpty().WithMessage(notEmptyMessage)
                .InclusiveBetween(1000, 9999);

            RuleFor(x => x.Month)
                .NotEmpty().WithMessage(notEmptyMessage)
                .InclusiveBetween(1, 12);

            RuleFor(x => x.Day)
                .NotEmpty().WithMessage(notEmptyMessage)
                .InclusiveBetween(1, 31);
        }
    }
}
