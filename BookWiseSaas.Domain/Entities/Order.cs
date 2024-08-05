using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Domain.Entities
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public string Status { get; set; } // Örneğin: "Pending", "Completed"

        public string Description { get; set; } // Sipariş açıklaması

        public ICollection<string> Urls { get; set; } // Siparişle ilişkili resim URL'leri

        public ICollection<Book> Books { get; set; } // Siparişteki kitaplar

        public ICollection<Recommendation> Recommendations { get; set; } // Siparişteki öneriler
    }
}
