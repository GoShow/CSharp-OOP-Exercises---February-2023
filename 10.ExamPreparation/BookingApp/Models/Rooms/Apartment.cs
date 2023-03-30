namespace BookingApp.Models.Rooms;

public class Apartment : Room
{
    private const int ApartmentBedCapacity = 6;

    public Apartment()
        : base(ApartmentBedCapacity)
    {
    }
}
