using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Domain.Entities
{
    public class UserBalanceHistory
    {
        public Guid Id { get; set; }
        public Guid UserBalanceId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public int Amount { get; set; } // Eklenen veya çıkarılan kredi miktarı
        public string Type { get; set; } // Örneğin: "Add", "Deduct"
        public int PreviousCredits { get; set; } // Önceki bakiye
        public int CurrentCredits { get; set; } // Güncel bakiye
    }
}
