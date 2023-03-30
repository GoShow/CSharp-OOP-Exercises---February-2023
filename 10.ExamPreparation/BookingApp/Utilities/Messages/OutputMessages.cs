namespace BookingApp.Utilities.Messages
{
    public static class OutputMessages
    {
        public const string HotelAlreadyRegistered = "Hotel {0} is already registered in our platform.";

        public const string HotelSuccessfullyRegistered = "{0} stars hotel {1} is registered in our platform and expects room availability to be uploaded.";

        public const string HotelNameInvalid = "Profile {0} doesn’t exist!";

        public const string RoomsAddedSuccessfully = "{0} {1} rooms successfully added in {2} hotel.";

        public const string RoomTypeInvalid = "Invalid operation, {0} type room is not active.";

        public const string RoomTypeNotCreated = "Room type is not created yet!";


        public const string RoomTypeAdded = "Successfully added {0} room type in {1} hotel!";

        public const string PriceSetSuccessfully = "Price of {0} room type in {1} hotel is set!";

        public const string HotelNotRegistered = "Sorry, {0} hotel is still not registered in our platform.";

        public const string CategoryInvalid = "{0} star hotel is not available in our platform.";

        public const string RoomNotAppropriate = "We cannot offer appropriate room for your request.";

        public const string RoomTypeAlreadyCreated = "Room type is already created!";

        public const string BookingSuccessful = "Booking number {0} for {1} hotel is successful!";

    }
}
