using BookingHotel.Core.IServices;
using BookingHotel.Core.Models.Domain;
using BookingHotel.Core.Services.Communication;
using BookingHotel.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Controllers
{
    [Route("api/user/bookings")]
    [ApiController]
    public class UserBookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public UserBookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserBookings()
        {
            var result = await _bookingService.GetAllAsync();

            if(result == null)
            {
                return null;
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateBooking([FromBody] Booking booking)
        {
            // Xử lý yêu cầu tạo mới đặt vé của người dùng
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> CancelBooking(int id)
        {
            var result = _bookingService.RemoveAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            // Xử lý yêu cầu lấy thông tin đặt vé của người dùng theo ID
            var result = await _bookingService.GetByIdAsync(id);
            if (result == null)
            {
                //return string not found
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}/invoice")]
        public async Task<IActionResult> GetBookingInvoice(int id)
        {
            // Xử lý yêu cầu lấy hóa đơn của đặt vé của người dùng theo ID
            var result = await _bookingService.GetInvoiceByBookingId(id);
            if (result == null)
            {
                //return string not found
                return NotFound();
            }
            return Ok(result);
        }
    }
}
