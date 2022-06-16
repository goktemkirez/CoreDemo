using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı kısmı boş geçilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail boş geçilemez");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz!");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("En az 2 karakter giriniz.");
            RuleFor(x => x.WriterPassword).Matches("[A-Z]").WithMessage("Şifre büyük harf içermelidir.");
            RuleFor(x => x.WriterPassword).Matches("[0-9]").WithMessage("Şifre rakam içermelidir.");

            //RuleFor(x => x.ConfirmPassword)
            //.Equal(x => x.Password)
            //.WithMessage("Passwords do not match");
        }
    }
}
