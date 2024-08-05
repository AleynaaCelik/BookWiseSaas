using BookWiseSaas.Application.Common.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWiseSaas.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(int id);
        Task RegisterUserAsync(UserDto userDto);
        Task<UserDto> AuthenticateUserAsync(string username, string password);
        Task UpdateUserProfileAsync(UserDto userDto);

    }
}
