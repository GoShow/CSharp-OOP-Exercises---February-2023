using System;

namespace ClassBoxData.Models;

public class Box
{
    private const string PropertyValueExceptionMessage = "{0} cannot be zero or negative.";

    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public double Length
    {
        get => length;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException(string.Format(PropertyValueExceptionMessage, nameof(Length)));
            }

            length = value;
        }
    }
    public double Width
    {
        get => width;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException(string.Format(PropertyValueExceptionMessage, nameof(Width)));
            }

            width = value;
        }
    }
    public double Height
    {
        get => height;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException(string.Format(PropertyValueExceptionMessage, nameof(Height)));
            }

            height = value;
        }
    }

    public int Age { get; set; }

    public double SurfaceArea() => 2 * Length * Width + LateralSurfaceArea();
    public double LateralSurfaceArea() => 2 * Length * Height + 2 * Width * Height;
    public double Volume() => Length * Width * Height;
}
