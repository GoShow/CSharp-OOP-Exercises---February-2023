namespace BookingApp.Models.Hotels.Contacts
{
    using BookingApp.Repositories.Contracts;
    using global::BookingApp.Models.Bookings.Contracts;
    using global::BookingApp.Models.Rooms.Contracts;
    using System.Collections.Generic;
    public interface IHotel
    {
        string FullName { get; }
        int Category { get; }
        double Turnover { get; }

        public IRepository<IRoom> Rooms { get; }
        public IRepository<IBooking> Bookings { get; }
    }
}
