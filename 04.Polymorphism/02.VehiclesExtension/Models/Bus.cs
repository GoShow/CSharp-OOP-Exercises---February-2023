namespace VehiclesExtension.Models;

public class Bus : Vehicle
{
    private const double IncreasedConsumption = 1.4;

    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption, tankCapacity, IncreasedConsumption)
    { }
}
