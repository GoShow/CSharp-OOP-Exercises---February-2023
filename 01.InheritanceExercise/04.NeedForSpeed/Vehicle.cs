namespace NeedForSpeed;

public abstract class Vehicle
{
    private const double DefaultFuelConsumption = 1.25;

    public Vehicle(int horsePower, double fuel)
    {
        HorsePower = horsePower;
        Fuel = fuel;
    }

    public int HorsePower { get; set; }

    public double Fuel { get; set; }

    public virtual double FuelConsumption => DefaultFuelConsumption;

    public virtual void Drive(double kilometers)
        => Fuel -= kilometers * FuelConsumption;
}
