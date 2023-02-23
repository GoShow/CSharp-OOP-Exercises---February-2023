namespace Restaurant;

public class Dessert : Food
{
    public Dessert(string name, decimal price, double grams, double calories)
        : base(name, price, grams)
    {
        Calories = calories;
    }

    public double Calories { get; private set; }
}
