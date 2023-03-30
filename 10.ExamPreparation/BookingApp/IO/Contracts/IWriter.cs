﻿namespace BookingApp.IO.Contracts
{
    public interface IWriter
    {
        void WriteLine(string message);
        void Write(string message);
    }
}
