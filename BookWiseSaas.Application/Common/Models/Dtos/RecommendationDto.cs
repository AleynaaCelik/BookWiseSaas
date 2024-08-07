using System;
using System.Collections.Generic;

namespace BookWiseSaas.Application.Common.Models.Dtos
{
    public class RecommendationDto
    {
        public Guid Id { get; set; } // Eklenen Id özelliği
        public Guid UserId { get; set; }
        public List<BookDto> RecommendedBooks { get; set; }
        public string Reason { get; set; } // Reason yerine RecommendationText kullanmak istiyorsanız bunu güncelleyin
    }
}
