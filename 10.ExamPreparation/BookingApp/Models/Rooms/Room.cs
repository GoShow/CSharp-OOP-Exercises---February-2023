using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;

namespace BookingApp.Models.Rooms;

public abstract class Room : IRoom
{
    private double pricePerNight;

    protected Room(int bedCapacity)
    {
        BedCapacity = bedCapacity;
    }

    public int BedCapacity { get; private set; }

    public double PricePerNight
    {
        get => pricePerNight;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
            }

            pricePerNight = value;
        }
    }

    public void SetPrice(double price)
    {
        PricePerNight = price;
    }
}
