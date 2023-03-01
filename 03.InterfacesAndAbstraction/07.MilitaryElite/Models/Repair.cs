using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models;
public class Repair : IRepair
{
    public Repair(string partName, int hoursWorked)
    {
        PartName = partName;
        HoursWorked = hoursWorked;
    }

    public string PartName { get; private set; }

    public int HoursWorked { get; private set; }

    public override string ToString()
        => $"Part Name: {PartName} Hours Worked: {HoursWorked}";
}
