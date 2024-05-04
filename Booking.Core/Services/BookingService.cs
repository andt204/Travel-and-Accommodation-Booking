using BookingHotel.Core.IRepositories;
using BookingHotel.Core.IServices;
using BookingHotel.Core.IUnitOfWorks;
using BookingHotel.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.Core.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWorks;
        private readonly IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWorks = unitOfWork;
            _bookingRepository = bookingRepository;
        }
        public async Task AddAsync(Booking booking)
        {
            await _bookingRepository.AddAsync(booking);
            _ = _unitOfWorks.CompleteAsync();
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _bookingRepository.GetAllAsync();
        }

        public async Task<Booking?> GetByIdAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var booking = await _bookingRepository.GetByIdAsync(id);
            return booking;
        }

        public async Task RemoveAsync(Booking booking)
        {
            if (booking == null)
            {
                throw new ArgumentNullException(nameof(booking));
            }
            await _bookingRepository.RemoveAsync(booking);
            _ = _unitOfWorks.CompleteAsync();
        }

        public async Task UpdateAsync(Booking booking)
        {
            if(booking == null)
            {
                throw new ArgumentNullException(nameof(booking));
            }
            await _bookingRepository.UpdateAsync(booking);
            _ = _unitOfWorks.CompleteAsync();
        }
    }
}
