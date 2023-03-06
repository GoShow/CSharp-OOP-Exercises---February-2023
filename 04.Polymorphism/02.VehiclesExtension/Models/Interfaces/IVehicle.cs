namespace VehiclesExtension.Models.Interfaces;

public interface IVehicle
{
    public double FuelQuantity { get; }

    public double FuelConsumption { get; }

    public string Drive(double distance, bool isIncreasedConsumption = true);

    public void Refuel(double amount);
}