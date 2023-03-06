namespace Raiding.Models;

public class Paladin : Hero
{
    private const int DefaultPower = 100;

    public Paladin(string name) : base(name, DefaultPower) { }

    public override string CastAbility()
        => $"{this.GetType().Name} - {Name} healed for {Power}";
}
