﻿using BookingHotel.Core.Context;
using BookingHotel.Core.IRepositories;
using BookingHotel.Core.IUnitOfWorks;
using BookingHotel.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace BookingHotel.Core.IUnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookingHotelDbContext _context;
        private IBookingRepository _bookingRepository;

        public UnitOfWork(BookingHotelDbContext context)
        {
            _context = context;
        }

        public IBookingRepository BookingRepository => _bookingRepository = _bookingRepository ?? new BookingRepository(_context);

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
=======
namespace BookingHotel.Core.IUnitOfWorks {
    public class UnitOfWork : IUnitOfWork {
        private readonly BookingHotelDbContext _context;

        public UnitOfWork(BookingHotelDbContext context) {
            _context = context;
        }

        public async Task CompleteAsync() {
            await _context.SaveChangesAsync();
        }
    }
}
>>>>>>> andt
