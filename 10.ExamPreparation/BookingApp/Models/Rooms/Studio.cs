namespace BookingApp.Models.Rooms;

public class Studio : Room
{
    private const int StudioBedCapacity = 4;

    public Studio()
        : base(StudioBedCapacity)
    {
    }
}
