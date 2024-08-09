using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BookWiseSaas.Domain.Entities;

namespace BookWiseSaas.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Define the table name if different from the default convention
            builder.ToTable("Orders");

            // Define the primary key
            builder.HasKey(o => o.Id);

            // Define required properties
            builder.Property(o => o.UserId)
                .IsRequired();

            builder.Property(o => o.CreatedOn)
                .IsRequired();

            builder.Property(o => o.Status)
                .IsRequired()
                .HasMaxLength(50); // Adjust length as needed

            // Configure optional properties
            builder.Property(o => o.Description)
                .HasMaxLength(500); // Adjust length as needed

            builder.Property(o => o.UserPreferences)
                .HasMaxLength(1000); // Adjust length as needed

            builder.Property(o => o.Mood)
                .HasMaxLength(100); // Adjust length as needed

            builder.Property(o => o.Language)
                .HasMaxLength(50); // Adjust length as needed

            builder.Property(o => o.PreviousReads)
                .HasMaxLength(1000); // Adjust length as needed

            // Configure collections - Make sure related entities have proper configurations
            builder.HasMany(o => o.Books)
                .WithOne() // Assuming no navigation property in Book entity
                .HasForeignKey("OrderId") // The foreign key property in Book entity
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(o => o.Recommendations)
                .WithOne() // Assuming no navigation property in Recommendation entity
                .HasForeignKey("OrderId") // The foreign key property in Recommendation entity
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
