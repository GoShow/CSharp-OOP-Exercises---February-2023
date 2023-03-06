using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Foods;

public abstract class Food : IFood
{
    protected Food(int quantity)
    {
        Quantity = quantity;
    }

    public int Quantity { get; private set; }
}
