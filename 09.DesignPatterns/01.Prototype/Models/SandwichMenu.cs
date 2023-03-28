using System.Collections.Generic;

namespace Prototype.Models;

public class SandwichMenu
{
    private IDictionary<string, SandwichPrototype> sandwiches;

    public SandwichMenu()
    {
        sandwiches = new Dictionary<string, SandwichPrototype>();
    }

    public SandwichPrototype this[string name]
    {
        get => sandwiches[name];
        set => sandwiches[name] = value;
    }
}
