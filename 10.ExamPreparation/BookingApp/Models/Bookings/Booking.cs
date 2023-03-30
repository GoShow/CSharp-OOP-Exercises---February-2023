using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Text;

namespace BookingApp.Models.Bookings;

public class Booking : IBooking
{
    private int residenceDuration;
    private int adultsCount;
    private int childrenCount;

    public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
    {
        Room = room;
        ResidenceDuration = residenceDuration;
        AdultsCount = adultsCount;
        ChildrenCount = childrenCount;
        BookingNumber = bookingNumber;
    }

    public IRoom Room { get; private set; }

    public int ResidenceDuration
    {
        get => residenceDuration;
        private set
        {
            if (value < 1)
            {
                throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
            }

            residenceDuration = value;
        }
    }

    public int AdultsCount
    {
        get => adultsCount;
        private set
        {
            if (value < 1)
            {
                throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
            }

            adultsCount = value;
        }
    }

    public int ChildrenCount
    {
        get => childrenCount;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.ChildrenNegative);
            }

            childrenCount = value;
        }
    }

    public int BookingNumber { get; private set; }


    public string BookingSummary()
    {
        StringBuilder sb = new();

        sb.AppendLine($"Booking number: {BookingNumber}");
        sb.AppendLine($"Room type: {Room.GetType().Name}");
        sb.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
        sb.AppendLine($"Total amount paid: {TotalPaid():f2} $");

        return sb.ToString().TrimEnd();
    }

    private double TotalPaid()
        => Math.Round(Room.PricePerNight * residenceDuration, 2);

}
