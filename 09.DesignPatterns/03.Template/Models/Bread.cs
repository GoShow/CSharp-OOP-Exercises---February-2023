using System;

namespace Template.Models;

public abstract class Bread
{
    public abstract void MixIngredients();

    public abstract void Bake();

    public virtual void Slice()
    {
        Console.WriteLine($"Slicing the {GetType().Name} bread!");
    }

    public void Make()
    {
        MixIngredients();
        Bake();
        Slice();
    }
}
