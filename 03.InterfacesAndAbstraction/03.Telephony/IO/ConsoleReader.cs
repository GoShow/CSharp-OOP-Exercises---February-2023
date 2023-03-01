using System;
using Telephony.IO.Interfaces;

namespace Telephony.IO;
public class ConsoleReader : IReader
{
    public string ReadLine() => Console.ReadLine();
}
