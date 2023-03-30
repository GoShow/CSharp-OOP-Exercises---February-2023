using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;

namespace BookingApp.Models.Bookings.Contracts
{
    public interface IBooking
    {        
        IRoom Room { get; }
        int ResidenceDuration { get; }
        int AdultsCount { get; }
        int ChildrenCount { get; }
        public int BookingNumber { get;}
        string BookingSummary();
    }
}
