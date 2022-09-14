using FluentValidation;
using HangfireApp.Web.Models;

namespace HangfireApp.Web.FluentValidators
{
    public class PictureSaveVMValidator : AbstractValidator<PictureSaveVM>
    {
        public PictureSaveVMValidator()
        {
            RuleFor(x => x.Image.Length).LessThanOrEqualTo(5242880)
                .WithMessage("Dosya boyutu 5 MB'tan büyük olamaz");

            RuleFor(x => x.Image.ContentType).Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                .WithMessage("Sadece jpg/jpeg/png formatındaki dosyalar yüklenebilir");
        }
    }
}
