<<<<<<< HEAD
﻿using BookingHotel.Core.Models.DTOs;
using BookingHotel.Models.Domain;
using System;
=======
﻿using System;
>>>>>>> andt
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD

namespace BookingHotel.Core.Mapping
{
    public class ModelToResourceProfile : AutoMapper.Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Booking, BookingDTO>().ReverseMap(); 
=======
using AutoMapper;
using BookingHotel.Core.Models.Domain;
using BookingHotel.Core.Models.DTOs;

namespace BookingHotel.Core.Mapping {
    public class ModelToResourceProfile : Profile {
        public ModelToResourceProfile() {
            CreateMap<Hotel, HotelDto>();
>>>>>>> andt
        }
    }
}
