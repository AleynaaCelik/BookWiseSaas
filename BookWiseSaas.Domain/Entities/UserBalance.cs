using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Domain.Entities
{
    public class UserBalance
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int Credits { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
    }
}
