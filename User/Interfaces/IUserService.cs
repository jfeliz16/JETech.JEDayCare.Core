using JETech.JEDayCare.Core.Data.Entities;
using JETech.JEDayCare.Core.User.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace JETech.JEDayCare.Core.User.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> CreateAsync(UserModel user);
        Task AddUserToRoleAsync(Data.Entities.User user, string roleName);
        Task CheckRoleAsync(string roleName);
        Task<bool> DeleteUserAsync(string email);
        Task<Data.Entities.User> GetUserByEmailAsync(string email);
        Task<bool> IsUserInRoleAsync(Data.Entities.User user, string roleName);
        Task<SignInResult> LoginAsync(LoginModel model);
        Task LogoutAsync();
        Task<IdentityResult> UpdateUserAsync(Data.Entities.User user);
    }
}