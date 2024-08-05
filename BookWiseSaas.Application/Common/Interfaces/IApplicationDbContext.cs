using BookWiseSaas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Recommendation> Recommendations { get; set; }
        DbSet<UserBalance> UserBalances { get; set; }
        DbSet<UserBalanceHistory> UserBalanceHistories { get; set; }
        DbSet<Order> Orders { get; set; }
        // Diğer DbSet'leri buraya ekleyin

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
