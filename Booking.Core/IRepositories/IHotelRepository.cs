using BookingHotel.Core.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.Core.IRepositories
{
    public interface IHotelRepository {
        Task<IEnumerable<Hotel>> ListAsync();
        Task AddAsync(Hotel hotel);
    }
}
