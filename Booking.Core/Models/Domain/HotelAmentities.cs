using BookingHotel.Core.Models.Domain;

namespace BookingHotel.Models.Domain {
    public class HotelAmentities {
        public int Id { get; set; }


        public int HotelId { get; set; }
        public int AmenityId { get; set; }


        public Hotel Hotel { get; set; }
        public Amenity Amenity { get; set; }

    }
}
