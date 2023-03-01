using FoodShortage.Models.Interfaces;

namespace FoodShortage.Models;

public class Citizen : IIdentifiable, IBirthable, INameable, IBuyer
{
    private const int DefaultFoodIncrement = 10;

    public Citizen(string id, string name, int age, string birthDate)
    {
        Id = id;
        Name = name;
        Age = age;
        Birthdate = birthDate;
    }

    public string Id { get; private set; }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public string Birthdate { get; private set; }

    public int Food { get; private set; }

    public void BuyFood()
    {
        Food += DefaultFoodIncrement;
    }
}
