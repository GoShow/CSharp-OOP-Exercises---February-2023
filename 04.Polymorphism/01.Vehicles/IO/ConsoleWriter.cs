using System;
using Vehicles.IO.Interfaces;

namespace Vehicles.IO;

public class ConsoleWriter : IWriter
{
    public void WriteLine(string str) => Console.WriteLine(str);
}

