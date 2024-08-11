using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Infrastructure.Persistance.Configuration
{
    public class UserLoginConfiguration : IEntityTypeConfiguration<>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserLogin> builder)
        {
            throw new NotImplementedException();
        }
    }
}
