using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace BookingApp.Core;

public class Controller : IController
{
    private readonly IRepository<IHotel> hotels;

    public Controller()
    {
        hotels = new HotelRepository();
    }

    public string AddHotel(string hotelName, int category)
    {
        IHotel hotel = hotels.Select(hotelName);

        if (hotel != null)
        {
            return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
        }

        hotel = new Hotel(hotelName, category);

        hotels.AddNew(hotel);

        return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName); ;
    }

    public string UploadRoomTypes(string hotelName, string roomTypeName)
    {
        IHotel hotel = hotels.Select(hotelName);

        if (hotel == null)
        {
            return string.Format(OutputMessages.HotelNameInvalid, hotelName);
        }

        IRoom room = hotel.Rooms.Select(roomTypeName);

        if (room != null)
        {
            return OutputMessages.RoomTypeAlreadyCreated;
        }

        switch (roomTypeName)
        {
            case nameof(DoubleBed):
                room = new DoubleBed();
                break;
            case nameof(Studio):
                room = new Studio();
                break;
            case nameof(Apartment):
                room = new Apartment();
                break;
            default:
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
        }

        hotel.Rooms.AddNew(room);

        return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
    }

    public string SetRoomPrices(string hotelName, string roomTypeName, double price)
    {
        IHotel hotel = hotels.Select(hotelName);

        if (hotel == null)
        {
            return string.Format(OutputMessages.HotelNameInvalid, hotelName);
        }

        if (roomTypeName != nameof(DoubleBed) && roomTypeName != nameof(Studio) && roomTypeName != nameof(Apartment))
        {
            throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
        }

        IRoom room = hotel.Rooms.Select(roomTypeName);

        if (room == null)
        {
            return OutputMessages.RoomTypeNotCreated;
        }

        if (room.PricePerNight > 0)
        {
            throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
        }

        room.SetPrice(price);

        return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
    }

    public string BookAvailableRoom(int adults, int children, int duration, int category)
    {
        if (hotels.All().FirstOrDefault(h => h.Category == category) == null)
        {
            return string.Format(OutputMessages.CategoryInvalid, category);
        }

        IOrderedEnumerable<IHotel> orderedHotels = hotels
            .All()
            .Where(h => h.Category == category)
            .OrderBy(h => h.FullName);

        foreach (var hotel in orderedHotels)
        {
            IRoom room = hotel.Rooms
                .All()
                .Where(r => r.PricePerNight > 0)
                .OrderBy(r => r.BedCapacity)
                .FirstOrDefault(r => r.BedCapacity >= adults + children);

            if (room != null)
            {
                int bookingNumber = hotel.Bookings.All().Count() + 1;

                IBooking booking = new Booking(room, duration, adults, children, bookingNumber);

                hotel.Bookings.AddNew(booking);

                return string.Format(OutputMessages.BookingSuccessful, bookingNumber, hotel.FullName);
            }
        }

        return OutputMessages.RoomNotAppropriate;
    }

    public string HotelReport(string hotelName)
    {
        IHotel hotel = hotels.Select(hotelName);

        if (hotel == null)
        {
            return string.Format(OutputMessages.HotelNameInvalid, hotelName);
        }

        StringBuilder sb = new();

        sb.AppendLine($"Hotel name: {hotel.FullName}");
        sb.AppendLine($"--{hotel.Category} star hotel");
        sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
        sb.AppendLine($"--Bookings:");
        sb.AppendLine();

        if (hotel.Bookings.All().Count == 0)
        {
            sb.AppendLine("none");
        }
        else
        {
            foreach (var booking in hotel.Bookings.All())
            {
                sb.AppendLine(booking.BookingSummary());
                sb.AppendLine();
            }
        }

        return sb.ToString().TrimEnd();
    }
}
