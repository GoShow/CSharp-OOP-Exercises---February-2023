namespace BookingApp.Models.Rooms.Contracts
{

    public interface IRoom
    {
        int BedCapacity { get; }
        double PricePerNight { get; }
        public void SetPrice(double price);
    }
}
