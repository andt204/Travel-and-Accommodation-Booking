using BookingHotel.Core.Models.Domain;
using BookingHotel.Core.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.Core.IServices
{
    public interface IHotelServices {
        Task<IEnumerable<Hotel>> ListAsync();
        Task<HotelResponse> SaveAsync(Hotel hotel);
    }
}
