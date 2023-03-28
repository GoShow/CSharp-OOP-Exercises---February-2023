using System;

namespace Template.Models;

public class WholeWheat : Bread
{
    public override void MixIngredients()
    {
        Console.WriteLine("Gathering ingredients for Whole Wheat Bread.");
    }
    public override void Bake()
    {
        Console.WriteLine("Baking the Whole Wheat Bread. (15 minutes)");
    }
}
