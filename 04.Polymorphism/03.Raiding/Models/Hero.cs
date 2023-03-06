using Raiding.Models.Interfaces;

namespace Raiding.Models;

public abstract class Hero : IHero
{
    protected Hero(string name, int power)
    {
        Name = name;
        Power = power;
    }

    public string Name { get; private set; }

    public int Power { get; private set; }

    public abstract string CastAbility();
}
