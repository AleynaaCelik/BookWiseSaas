using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Application.Common.Models.Dtos
{
    public class RecommendationDto
    {
        public Guid UserId { get; set; }
        public List<BookDto> RecommendedBooks { get; set; }
        public string Reason { get; set; }
    }
}
