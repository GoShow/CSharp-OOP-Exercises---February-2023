using MilitaryElite.Enums;
using MilitaryElite.Models.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models;

public class Commando : SpecialisedSoldier, ICommando
{
    public Commando(int id, string firstName, string lastName, decimal salary, Corps corps, IReadOnlyCollection<IMission> missions)
        : base(id, firstName, lastName, salary, corps)
    {
        Missions = missions;
    }

    public IReadOnlyCollection<IMission> Missions { get; private set; }

    public override string ToString()
    {
        StringBuilder sb = new();

        sb.AppendLine(base.ToString());
        sb.AppendLine("Missions:");

        foreach (var mission in Missions)
        {
            sb.AppendLine($"  {mission.ToString()}");
        }

        return sb.ToString().TrimEnd();
    }
}
