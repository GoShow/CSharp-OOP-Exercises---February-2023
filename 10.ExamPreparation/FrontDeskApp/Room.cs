using System;
using System.Collections.Generic;
using System.Text;

namespace FrontDeskApp
{
    public class Room
    {
        private int bedCapacity;
        private double pricePerNight;

        public Room(int bedCapacity, double pricePerNight)
        {
            BedCapacity = bedCapacity;
            PricePerNight = pricePerNight;
        }

        public int BedCapacity
        {
            get => bedCapacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                bedCapacity = value;
            }
        }

        public double PricePerNight
        {
            get => pricePerNight;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                pricePerNight = value;
            }
        }
    }
}
