using BookingHotel.Core.Models.DTOs;
using BookingHotel.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingHotel.Core.Mapping
{
    public class ModelToResourceProfile : AutoMapper.Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Booking, BookingDTO>().ReverseMap(); 
        }
    }
}
