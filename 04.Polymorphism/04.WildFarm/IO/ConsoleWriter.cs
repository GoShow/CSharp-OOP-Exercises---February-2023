using System;
using WildFarm.IO.Interfaces;

namespace Raiding.IO;

public class ConsoleWriter : IWriter
{
    public void WriteLine(object obj)
        => Console.WriteLine(obj);
}
