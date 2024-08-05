using BookWiseSaas.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Domain.Extensions
{
    public static class EntityExtensions
    {
        public static bool IsValid(this IEntity entity)
        {
            return entity != null && entity.Id != Guid.Empty;
        }
    }
}
