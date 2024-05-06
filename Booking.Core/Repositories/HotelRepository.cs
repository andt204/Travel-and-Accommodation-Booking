using BookingHotel.Core.Context;
using BookingHotel.Core.IRepositories;
using BookingHotel.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.Core.Repositories
{
    public class HotelRepository : BaseRepository, IHotelRepository {
        public HotelRepository(IBookingHotelDbContext context) : base(context) {
        }

        public Task AddAsync(Hotel hotel) {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Hotel>> ListAsync() {
            return await _context.Hotels.ToListAsync();
        }
    }
}
