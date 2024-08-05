using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Application.Common.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(string userId, string[] roles);
        ClaimsPrincipal ValidateToken(string token);
    }
}
