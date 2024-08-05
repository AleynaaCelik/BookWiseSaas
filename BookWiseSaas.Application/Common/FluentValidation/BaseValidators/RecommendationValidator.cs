using BookWiseSaas.Application.Common.Models.Dtos;
using FluentValidation;


public class RecommendationDtoValidator : AbstractValidator<RecommendationDto>
{
    public RecommendationDtoValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı ID'si boş olamaz.");
        RuleFor(x => x.RecommendedBooks)
            .NotEmpty().WithMessage("Önerilen kitaplar listesi boş olamaz.")
            .Must(x => x.Count > 0).WithMessage("Önerilen kitaplar listesi en az bir kitap içermelidir.");
        RuleFor(x => x.Reason).MaximumLength(1000).WithMessage("Sebep 1000 karakterden uzun olmamalıdır.");
    }
}
