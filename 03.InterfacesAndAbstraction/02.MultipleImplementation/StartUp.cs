using System;

//Do not remove because of judge. Don't put in folders because of the namespace.
namespace PersonInfo;

public class StartUp
{
    static void Main(string[] args)
    {
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        string id = Console.ReadLine();
        string birthdate = Console.ReadLine();

        IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
        IBirthable birthable = new Citizen(name, age, id, birthdate);
        Console.WriteLine(identifiable.Id);
        Console.WriteLine(birthable.Birthdate);

    }
}
