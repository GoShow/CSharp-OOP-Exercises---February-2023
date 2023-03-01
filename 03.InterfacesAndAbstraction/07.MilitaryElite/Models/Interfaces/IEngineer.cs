using System.Collections.Generic;

namespace MilitaryElite.Models.Interfaces;
public interface IEngineer : ISpecialisedSoldier
{
    IReadOnlyCollection<IRepair> Repairs { get; }
}
