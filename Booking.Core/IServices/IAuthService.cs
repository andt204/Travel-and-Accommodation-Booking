using BookingHotel.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookingHotel.Core.Models.DTOs.ServiceResponse;

namespace BookingHotel.Core.IServices
{
    public interface IAuthService
    {
        Task<LoginResponse> Signin(LoginDTO loginDTO);
        Task<GeneralResponse> Register(RegisterDTO register);
    }
}
