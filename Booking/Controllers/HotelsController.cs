using AutoMapper;
using BookingHotel.Core.IServices;
using BookingHotel.Core.Models.Domain;
using BookingHotel.Core.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers {
    [Route("/api/[controller]")]
    public class HotelsController : Controller {
        private readonly IHotelServices _hotelService;
        private readonly IMapper _mapper;
        public HotelsController(IHotelServices hotelService, IMapper mapper) {
            _hotelService = hotelService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<HotelDto>> GetAllAsync() {
            var hotels = await _hotelService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelDto>>(hotels);
            return resources;
        }
    }
}
