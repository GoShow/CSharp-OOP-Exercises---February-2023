namespace FoodShortage.Models.Interfaces;

public interface IBuyer : INameable
{
    int Food { get; }
    void BuyFood();
}
