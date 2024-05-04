﻿namespace BookingHotel.Models.Domain {
    public class Invoice {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookingId { get; set; }

        public DateTime DayExport { get; set; }

        public Booking Booking { get; set; }
       
    }
}