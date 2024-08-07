using BookWiseSaas.Application.Common.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Application.Features.Orders.Queries.GetAll
{
    public class OrderGetAllDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public List<string> Urls { get; set; }
        public List<BookDto> Books { get; set; }
        public List<RecommendationDto> Recommendations { get; set; }
    }
}
