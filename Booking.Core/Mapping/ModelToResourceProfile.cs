using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingHotel.Core.Models.Domain;
using BookingHotel.Core.Models.DTOs;

namespace BookingHotel.Core.Mapping {
    public class ModelToResourceProfile : Profile {
        public ModelToResourceProfile() {
            CreateMap<Hotel, HotelDto>();
        }
    }
}
