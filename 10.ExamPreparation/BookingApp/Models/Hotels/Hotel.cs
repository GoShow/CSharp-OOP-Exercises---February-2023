using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Linq;

namespace BookingApp.Models.Hotels;

public class Hotel : IHotel
{
    private string fullName;
    private int category;

    public Hotel(string fullName, int category)
    {
        FullName = fullName;
        Category = category;
        Rooms = new RoomRepository();
        Bookings = new BookingRepository();
    }

    public string FullName
    {
        get => fullName;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
            }

            fullName = value;
        }
    }

    public int Category
    {
        get => category;
        private set
        {
            if (value < 1 || value > 5)
            {
                throw new ArgumentException(ExceptionMessages.InvalidCategory);
            }

            category = value;
        }
    }

    public double Turnover
        => Math.Round(Bookings.All().Sum(b => b.ResidenceDuration * b.Room.PricePerNight), 2);

    public IRepository<IRoom> Rooms { get; set; }

    public IRepository<IBooking> Bookings { get; set; }
}
