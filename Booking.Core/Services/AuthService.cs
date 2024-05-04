using BookingHotel.Core.IServices;
using BookingHotel.Core.Models.Domain;
using BookingHotel.Core.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> Register(RegisterDTO register)
        {
            if (register == null)
            {
                throw new ArgumentNullException(nameof(register));
            }
            var identityUser = new User
            {
                Email = register.Email,
                UserName = register.Email
            };
            var identityResult = await _userManager.CreateAsync(identityUser, register.Password);

            if (identityResult.Succeeded)
            {
                //add role for user
                if (register.Roles != null && register.Roles.Any())
                {
                    identityResult = await _userManager.AddToRolesAsync(identityUser, register.Roles);
                    if (identityResult.Succeeded)
                    {
                        return "User created successfully! Pls login";
                    }
                }
            }
            return "User created failed!";
        }

        public async Task<string> Signin(LoginDTO loginDTO)
        {
            if (loginDTO == null)
            {
                return "Invalid login";
            }
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user != null)
            {
                var result = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
                if (result)
                {
                    return "Login success";
                }
                else
                {
                    return "Invalid login";
                }
            }
            return "Invalid login";
        }
    }
}
