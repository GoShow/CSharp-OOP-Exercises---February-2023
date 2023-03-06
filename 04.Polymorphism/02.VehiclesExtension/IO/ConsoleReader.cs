using System;
using VehiclesExtension.IO.Interfaces;

namespace VehiclesExtension.IO;

public class ConsoleReader : IReader
{
    public string ReadLine() => Console.ReadLine();
}
