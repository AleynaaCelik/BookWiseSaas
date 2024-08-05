using BookWiseSaas.Application.Common.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Application.Common.Models
{
    public class RecommendationResponse
    {
        public List<BookRecommendationDto> Recommendations { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
