namespace SimpleSnake.GameObjects.Foods;

public class FoodAsterisk : Food
{
    private const char FoodSymbol = '*';
    private const int Points = 1;
    public FoodAsterisk(Wall wall)
        : base(wall, FoodSymbol, Points)
    {
    }
}
