using BookingHotel.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace BookingHotel.Core.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly BookingHotelDbContext _context;

        public BaseRepository(BookingHotelDbContext context)
        {
=======
namespace BookingHotel.Core.Repositories {
    public abstract class BaseRepository {
        protected readonly IBookingHotelDbContext _context;

        public BaseRepository(IBookingHotelDbContext context) {
>>>>>>> andt
            _context = context;
        }
    }
}
