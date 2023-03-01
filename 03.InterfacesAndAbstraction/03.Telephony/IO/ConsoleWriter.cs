using System;
using Telephony.IO.Interfaces;

namespace Telephony.IO;
public class ConsoleWriter : IWriter
{
    public void WriteLine(string line) => Console.WriteLine(line);
}
