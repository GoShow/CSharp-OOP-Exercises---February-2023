namespace Restaurant;

public class Food : Product
{
    public Food(string name, decimal price, double grams)
        : base(name, price)
    {
        Grams = grams;
    }

    public double Grams { get; private set; }
}
