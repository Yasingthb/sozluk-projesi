using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş bırakılamaz.");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar soyadı boş bırakılamaz. ");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda kısmı boş bırakılamaz. ");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan kısmı boş bırakılamaz. ");

            RuleFor(x => x.WriterAbout).Matches("[aA]").WithMessage("Hakkında kısmında a/A harfi olmalı");
            RuleFor(x => x.WriterSurName).MinimumLength(2).WithMessage("En az 2 karakter olmalıdır.");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("En fazla 50 karakter olmalıdır.");
        }
    }
}
