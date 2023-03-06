using System;
using Vehicles.IO.Interfaces;

namespace Vehicles.IO;

public class ConsoleReader : IReader
{
    public string ReadLine() => Console.ReadLine();
}
