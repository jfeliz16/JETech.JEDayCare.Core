using JETech.JEDayCare.Core.User.Helper;
using JETech.JEDayCare.Core.User.Interfaces;
using JETech.JEDayCare.Core.User.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JETech.JEDayCare.Core.User.Services
{
    public class UserService :IUserService
    {       
        private readonly UsersManager _usersManager;

        public UserService(
            UserManager<Data.Entities.User> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<Data.Entities.User> signInManager)
        {
            _usersManager = new UsersManager(userManager, roleManager, signInManager);
        }

        public async Task<IdentityResult> CreateAsync(UserModel user)
        {
                return await _usersManager.CreateAsync(user);          
        }

        public async Task AddUserToRoleAsync(Data.Entities.User user, string roleName)
        {
            await _usersManager.AddUserToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            await _usersManager.CheckRoleAsync(roleName);
        }

        public async Task<Data.Entities.User> GetUserByEmailAsync(string email)
        {
            return await _usersManager.GetUserByEmailAsync(email);            
        }

        public async Task<bool> IsUserInRoleAsync(Data.Entities.User user, string roleName)
        {
            return await _usersManager.IsUserInRoleAsync(user, roleName);
        }

        public async Task<SignInResult> LoginAsync(LoginModel model)
        {
            return await _usersManager.LoginAsync(model);
        }

        public async Task LogoutAsync()
        {
            await _usersManager.LogoutAsync();
        }

        public async Task<bool> DeleteUserAsync(string email)
        {   
            return await _usersManager.DeleteUserAsync(email);
        }

        public async Task<IdentityResult> UpdateUserAsync(Data.Entities.User user)
        {
            return await _usersManager.UpdateUserAsync(user);
        }
    }
}
