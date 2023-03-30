namespace BookingApp.Utilities.Messages
{
    public static class ExceptionMessages
    {
        public const string PricePerNightNegative = "Price cannot be negative!";

        public const string CannotCorrectPriceOfZero = "Initial price should be set first!";

        public const string CannotResetInitialPrice = "Price is already set!";

        public const string DurationZeroOrLess = "Duration cannot be negative or zero!";

        public const string AdultsZeroOrLess = "Adults count cannot be negative or zero!";

        public const string ChildrenNegative = "Children count cannot be negative!";

        public const string HotelNameNullOrEmpty = "Hotel name cannot be null or empty!";

        public const string InvalidCategory = "Category should be between 1 and 5 stars!";

        public const string RoomTypeNullOrEmpty = "Room type cannot be null or empty!";

        public const string RoomTypeIncorrect = "Incorrect room type!";

        public const string HotelNullOrEmpty = "Hotel cannot be null or empty!";

        public const string NotEnoughCapacity = "Not enough capacity.";

        public const string NoRoomsAvailable = "Requested room is not available.";

        public const string AmountNegative = "Booking amount cannot be negative!";

        public const string PriceAlreadySet = "Price is already set!";
    }
}
