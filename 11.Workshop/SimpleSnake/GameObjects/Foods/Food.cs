using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects.Foods;

public abstract class Food : Point
{
    private Wall wall;
    private char foodSymbol;
    private Random random;

    protected Food(Wall wall, char foodSymbol, int points)
        : base(wall.LeftX, wall.TopY)
    {
        this.wall = wall;
        this.foodSymbol = foodSymbol;
        FoodPoints = points;
        random = new Random();
    }

    public int FoodPoints { get; set; }

    public void SetRandomPosition(Queue<Point> snakeElements)
    {
        LeftX = random.Next(2, wall.LeftX - 2);
        TopY = random.Next(2, wall.TopY - 2);

        bool isSnakeElement = snakeElements
            .Any(se => se.LeftX == LeftX && se.TopY == TopY);

        while (isSnakeElement)
        {
            LeftX = random.Next(2, wall.LeftX - 2);
            TopY = random.Next(2, wall.TopY - 2);

            isSnakeElement = snakeElements
                .Any(se => se.LeftX == LeftX && se.TopY == TopY);
        }

        Console.BackgroundColor = ConsoleColor.Red;
        Draw(foodSymbol);
        Console.BackgroundColor = ConsoleColor.White;
    }

    public bool IsFoodPoint(Point snakeHead)
        => snakeHead.LeftX == LeftX && snakeHead.TopY == TopY;
}
