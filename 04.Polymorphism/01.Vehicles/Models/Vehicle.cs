using System;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models;

public abstract class Vehicle : IVehicle
{
    private double increasedConsumption;

    protected Vehicle(double fuelQuantity, double fuelConsumption, double increasedConsumption)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
        this.increasedConsumption = increasedConsumption;
    }

    public double FuelQuantity { get; private set; }

    public double FuelConsumption { get; private set; }

    public string Drive(double distance)
    {
        double consumption = FuelConsumption + increasedConsumption;

        if (FuelQuantity < distance * consumption)
        {
            throw new ArgumentException($"{this.GetType().Name} needs refueling");
        }

        FuelQuantity -= distance * consumption;

        return $"{this.GetType().Name} travelled {distance} km";
    }

    public virtual void Refuel(double amount)
        => FuelQuantity += amount;

    public override string ToString()
        => $"{this.GetType().Name}: {FuelQuantity:F2}";
}
