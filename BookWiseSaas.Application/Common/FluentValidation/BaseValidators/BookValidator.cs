using FluentValidation;
using BookWiseSaas.Application.Common.Models.Dtos;

namespace BookWiseSaas.Application.Common.FluentValidation.BaseValidators
{
    public class BookValidator : AbstractValidator<BookDto>
    {
        public BookValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş olamaz.");
            RuleFor(x => x.Author).NotEmpty().WithMessage("Yazar adı boş olamaz.");
            RuleFor(x => x.ISBN)
                .Length(13).WithMessage("ISBN 13 karakter uzunluğunda olmalıdır.")
                .Matches(@"^\d+$").WithMessage("ISBN yalnızca rakam içermelidir.");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Açıklama 500 karakterden uzun olmamalıdır.");
        }
    }
}
//ISBN, International Standard Book Number (Uluslararası Standart Kitap Numarası) anlamına gelir. Kitapların tanımlanmasını ve bulunmasını kolaylaştıran bir numaralandırma sistemidir. ISBN, her kitaba benzersiz bir numara verir, bu da kitapların ve diğer yayınların etkin bir şekilde yönetilmesini sağlar