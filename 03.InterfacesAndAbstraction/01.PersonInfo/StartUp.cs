using System;

//Do not remove because of judge. Don't put in folders because of the namespace.
namespace PersonInfo;

public class StartUp
{
    static void Main(string[] args)
    {
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());

        IPerson person = new Citizen(name, age);

        Console.WriteLine(person.Name);
        Console.WriteLine(person.Age);
    }
}
