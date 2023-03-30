using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrontDeskApp
{
    public class Hotel
    {
        private string fullName;
        private int category;
        private double turnover = 0;
        private List<Room> rooms;
        private List<Booking> bookings;

        public Hotel(string fullName, int category)
        {
            this.FullName = fullName;
            this.Category = category;
            this.rooms = new List<Room>();
            this.bookings = new List<Booking>();
        }
        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }
                fullName = value;
            }
        }

        public int Category
        {
            get => category;
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException();
                }
                category = value;
            }
        }

        public double Turnover => this.turnover;

        public IReadOnlyCollection<Room> Rooms => this.rooms;
        public IReadOnlyCollection<Booking> Bookings => this.bookings;

        public void AddRoom(Room room)
        {
            this.rooms.Add(room);
        }

        public void BookRoom(int adults, int children, int residenceDuration, double budget)
        {
            if (adults <= 0)
            {
                throw new ArgumentException();
            }

            if (children < 0)
            {
                throw new ArgumentException();
            }

            if (residenceDuration < 1)
            {
                throw new ArgumentException();
            }

            int bedsNeeded = adults + children;

            foreach (var room in this.Rooms.OrderBy(x => x.BedCapacity))
            {
                if (room.BedCapacity >= bedsNeeded)
                {
                    if (budget >= residenceDuration * room.PricePerNight)
                    {
                        var booking = new Booking(this.bookings.Count + 1, room, residenceDuration);
                        this.bookings.Add(booking);
                        this.turnover += residenceDuration * room.PricePerNight;
                    }
                }
            }
        }
    }
}
