namespace SimpleSnake.GameObjects;

public class Wall : Point
{
    private const char WallSymbol = '\u25A0';

    public Wall(int leftX, int topY)
        : base(leftX, topY)
    {
        InitializeBorders();
    }

    public bool IsPointOfWall(Point snakeHead)
        => snakeHead.TopY == 0 ||
           snakeHead.LeftX == 0 ||
           snakeHead.LeftX == LeftX - 1 ||
           snakeHead.TopY == TopY;


    private void InitializeBorders()
    {
        SetHorizontalLine(0);
        SetHorizontalLine(TopY);

        SetVerticalLine(0);
        SetVerticalLine(LeftX - 1);
    }

    private void SetHorizontalLine(int topY)
    {
        for (int leftX = 0; leftX < LeftX; leftX++)
        {
            Draw(leftX, topY, WallSymbol);
        }
    }

    private void SetVerticalLine(int leftX)
    {
        for (int topY = 0; topY < TopY; topY++)
        {
            Draw(leftX, topY, WallSymbol);
        }
    }
}
