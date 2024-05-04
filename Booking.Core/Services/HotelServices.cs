using BookingHotel.Core.IRepositories;
using BookingHotel.Core.IServices;
using BookingHotel.Core.IUnitOfWorks;
using BookingHotel.Core.Models.Domain;
using BookingHotel.Core.Services.Communication;

namespace BookingHotel.Core.Services {
    public class HotelServices : IHotelServices {
        private readonly IHotelRepository _hotelRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HotelServices(IHotelRepository hotelRepository, IUnitOfWork unitOfWork) {
            _hotelRepository = hotelRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Hotel>> ListAsync() {
            return await _hotelRepository.ListAsync();
        }

        public async Task<HotelResponse> SaveAsync(Hotel hotel) {
            try {
                await _hotelRepository.AddAsync(hotel);
                await _unitOfWork.CompleteAsync();

                return new HotelResponse(hotel);
            } catch (Exception ex) {
                // Do some logging stuff
                return new HotelResponse($"An error occurred when saving the hotel: {ex.Message}");
            }
        }
    }
}
