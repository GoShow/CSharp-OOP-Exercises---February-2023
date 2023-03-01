using MilitaryElite.Models.Interfaces;
using System;

namespace MilitaryElite.Models;
public class Spy : Soldier, ISpy
{
    public Spy(int id, string firstName, string lastName, int codeNumber)
        : base(id, firstName, lastName)
    {
        CodeNumber = codeNumber;
    }

    public int CodeNumber { get; private set; }

    public override string ToString()
        => base.ToString() + $"{Environment.NewLine}Code Number: {CodeNumber}";
}
