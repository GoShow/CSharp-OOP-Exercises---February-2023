using System;
using WildFarm.Factories.Interfaces;
using WildFarm.Models.Animals;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories;

public class AnimalFactory : IAnimalFactory
{
    public IAnimal CreateAnimal(string[] animalArgs)
    {
        string type = animalArgs[0];
        string name = animalArgs[1];
        double weight = double.Parse(animalArgs[2]);

        switch (type)
        {
            case "Owl":
                return new Owl(name, weight, double.Parse(animalArgs[3]));
            case "Hen":
                return new Hen(name, weight, double.Parse(animalArgs[3]));
            case "Mouse":
                return new Mouse(name, weight, animalArgs[3]);
            case "Dog":
                return new Dog(name, weight, animalArgs[3]);
            case "Cat":
                return new Cat(name, weight, animalArgs[3], animalArgs[4]);
            case "Tiger":
                return new Tiger(name, weight, animalArgs[3], animalArgs[4]);
            default:
                throw new ArgumentException("Invalid animal type!");
        }
    }
}
