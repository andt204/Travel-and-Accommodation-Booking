using BookingHotel.Core.IRepositories;
using BookingHotel.Core.IServices;
using BookingHotel.Core.Models.Domain;
using BookingHotel.Core.Models.DTOs;
using BookingHotel.Core.Utilities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookingHotel.Core.Models.DTOs.ServiceResponse;

namespace BookingHotel.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly ISendEmailService _sendEmailService;
        private readonly ITokenRepository _tokenRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthService(UserManager<User> userManager, ITokenRepository tokenRepository, RoleManager<IdentityRole> roleManager, ISendEmailService sendEmailService)
        {
            _sendEmailService = sendEmailService;
            _userManager = userManager;
            _tokenRepository = tokenRepository;
            _roleManager = roleManager;
        }
        public async Task<GeneralResponse> Register(RegisterDTO register)
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
                //generate token for verify email
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);
                //encoder
                var code = System.Web.HttpUtility.UrlEncode(token);
                //generate link for verify email
                var link = $"https://localhost:5001/api/auth/verify-email?email={register.Email}&token={code}";
                //generate email content
                var content = $"<a href='{link}'>Click here to verify email</a>";
                //send email
                _ = SendEmail(register.Email, "Verify email", content);
                //add role for user
                if (_userManager.Options.SignIn.RequireConfirmedEmail)
                {
                    if (register.Roles != null && register.Roles.Any())
                    {
                        identityResult = await _userManager.AddToRolesAsync(identityUser, register.Roles);
                        if (identityResult.Succeeded)
                        {
                            return new GeneralResponse(true, "User created success! Please check your email to verify email");

                        }
                    }
                }
            }
            return new GeneralResponse(false, "User created fail");
        }

        //function to send email
        public async Task<string> SendEmail(string email, string subject, string htmlMessage)
        {
            await _sendEmailService.SendEmailAsync(email, subject, htmlMessage);
            return "Send email success";
        }

        public async Task<LoginResponse> Signin(LoginDTO loginDTO)
        {
            if (loginDTO == null)
            {
                return new LoginResponse(true, null!, "Login Fail");
            }

            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user != null)
            {
                var result = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
                if (result)
                {
                    //get role for this user
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles != null)
                    {
                        //generate token
                        var token = await _tokenRepository.GenerateToken(user, roles.ToList());

                        var userToken = new LoginResponseDTO
                        {
                            Token = token
                        };

                        return new LoginResponse(true, token!, "Login success");
                        //return Object.ReferenceEquals(userToken, null) ? "Login success" : "Login failed";
                    }
                    return new LoginResponse(true, null!, "Login Fail");
                }
            }
            return new LoginResponse(true, null!, "Login Fail");
        }

    }
}
