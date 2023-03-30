namespace BookingApp.Models.Rooms;

public class DoubleBed : Room
{
    private const int DoubleBedBedCapacity = 2;

    public DoubleBed() : base(DoubleBedBedCapacity)
    {
    }
}
