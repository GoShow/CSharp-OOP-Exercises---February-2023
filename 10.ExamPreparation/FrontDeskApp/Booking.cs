using System;
using System.Collections.Generic;
using System.Text;

namespace FrontDeskApp
{
    public class Booking
    {
        private Room room;
        private int residenceDuration;
        private int bookingNumber;

        public Booking(int bookingNumber, Room room, int residenceDuration)
        {
            BookingNumber = bookingNumber;
            Room = room;
            ResidenceDuration = residenceDuration;
        }

        public int BookingNumber 
        { 
            get => bookingNumber; 
            private set => bookingNumber = value; 
        }
        public Room Room 
        { 
            get => room; 
            private set => room = value; 
        }
        public int ResidenceDuration 
        { 
            get => residenceDuration; 
            private set => residenceDuration = value; 
        }
    }
}
