namespace BookingApp.IO
{
    using BookingApp.IO.Contracts;
    using System;
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
