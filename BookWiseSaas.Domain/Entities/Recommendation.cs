using BookWiseSaas.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Domain.Entities
{
    public class Recommendation : BaseEntity
    {
        public Guid UserId { get; set; }
        public List<Book> RecommendedBooks { get; set; }
        public string Reason { get; set; }
    }
}
