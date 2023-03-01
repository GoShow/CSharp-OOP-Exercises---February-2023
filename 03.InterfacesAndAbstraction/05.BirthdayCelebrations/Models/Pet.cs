using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations.Models;

public class Pet : INameable, IBirthable
{
    public Pet(string name, string birthDate)
    {
        Name = name;
        Birthdate = birthDate;
    }

    public string Name { get; private set; }

    public string Birthdate { get; private set; }
}
