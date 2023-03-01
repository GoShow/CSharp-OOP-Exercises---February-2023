using MilitaryElite.Enums;

namespace MilitaryElite.Models.Interfaces;

public interface ISpecialisedSoldier : IPrivate
{
    Corps Corps { get; }
}
