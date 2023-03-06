using Raiding.IO.Interfaces;
using System;

namespace Raiding.IO;

public class ConsoleWriter : IWriter
{
    public void WriteLine(string str) => Console.WriteLine(str);
}
