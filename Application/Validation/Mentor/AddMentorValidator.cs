using Application.DTOs.Mentor;
using Application.UseCases.Admin;
using FluentValidation;

namespace Application.Validation.Mentor;

public class AddMentorValidator : AbstractValidator<CreateMentorCommand>
{
    public AddMentorValidator()
    {
        RuleFor(m => m.Name).NotEmpty()
            .WithMessage("Lutfen mentor adi giriniz")
            .MaximumLength(50)
            .WithMessage("Mentor adi 50 karakterden fazla olamaz")
            .MinimumLength(3)
            .WithMessage("Mentor adi en az 3 karakter olmalidir");

        RuleFor(m => m.Surname).NotEmpty()
            .WithMessage("Lutfen mentor soyadi giriniz")
            .MaximumLength(50)
            .WithMessage("Mentor soyadi 50 karakterden fazla olamaz")
            .MinimumLength(3)
            .WithMessage("Mentor soyadi en az 3 karakter olmalidir");
        RuleFor(m=> m.Email).NotEmpty()
            .WithMessage("Lutfen email adresi giriniz")
            .EmailAddress()
            .WithMessage("Lutfen gecerli bir email adresi giriniz");
    }
}