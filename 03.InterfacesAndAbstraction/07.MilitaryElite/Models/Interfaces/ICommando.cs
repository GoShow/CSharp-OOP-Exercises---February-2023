using System.Collections.Generic;

namespace MilitaryElite.Models.Interfaces;

public interface ICommando : ISpecialisedSoldier
{
    IReadOnlyCollection<IMission> Missions { get; }
}
