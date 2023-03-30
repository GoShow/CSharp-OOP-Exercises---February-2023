using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repositories;

public class BookingRepository : IRepository<IBooking>
{
    private readonly List<IBooking> bookings;

    public BookingRepository()
    {
        bookings = new List<IBooking>();
    }

    public void AddNew(IBooking model)
        => bookings.Add(model);

    public IBooking Select(string criteria)
        => bookings.FirstOrDefault(b => b.BookingNumber.ToString() == criteria);

    public IReadOnlyCollection<IBooking> All()
        => bookings.AsReadOnly();
}
