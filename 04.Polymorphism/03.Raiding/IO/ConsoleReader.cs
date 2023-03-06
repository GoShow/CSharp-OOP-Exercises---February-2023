using Raiding.IO.Interfaces;
using System;

namespace Raiding.IO;

public class ConsoleReader : IReader
{
    public string ReadLine() => Console.ReadLine();
}
