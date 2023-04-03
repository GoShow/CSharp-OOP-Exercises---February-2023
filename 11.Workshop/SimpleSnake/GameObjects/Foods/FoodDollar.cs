namespace SimpleSnake.GameObjects.Foods;

public class FoodDollar : Food
{
    private const char FoodSymbol = '$';
    private const int Points = 2;
    public FoodDollar(Wall wall)
        : base(wall, FoodSymbol, Points)
    {
    }
}
