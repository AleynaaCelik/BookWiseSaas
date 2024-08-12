using BookWiseSaas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Infrastructure.Persistance.Configuration
{
    public class UserLoginConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256); // E-posta uzunluğu için bir sınırlama

            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(256); // Şifre hash uzunluğu için bir sınırlama

            // Diğer konfigürasyonlar
        }
    }
}
