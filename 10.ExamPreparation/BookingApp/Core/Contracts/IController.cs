namespace BookingApp.Core.Contracts
{

    public interface IController
    {
        string AddHotel(string hotelName, int category);
        string UploadRoomTypes(string hotelName, string roomTypeName);
        string SetRoomPrices(string hotelName, string roomTypeName, double price);
        string BookAvailableRoom(int adults, int children, int duration, int category);
        string HotelReport(string hotelName);
    }
}
