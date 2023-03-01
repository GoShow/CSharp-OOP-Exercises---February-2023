using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations.Models;

public class Citizen : IIdentifiable, INameable, IBirthable
{
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
}
