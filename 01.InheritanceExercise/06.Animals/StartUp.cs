using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            while (true)
            {
                string animalType = Console.ReadLine();

                if (animalType == "Beast!")
                {
                    break;
                }

                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    switch (animalType)
                    {
                        case "Dog":
                            Dog dog = new(tokens[0], int.Parse(tokens[1]), tokens[2]);
                            PrintAnimal(animalType, dog);
                            break;
                        case "Frog":
                            Frog frog = new(tokens[0], int.Parse(tokens[1]), tokens[2]);
                            PrintAnimal(animalType, frog);
                            break;
                        case "Cat":
                            Cat cat = new(tokens[0], int.Parse(tokens[1]), tokens[2]);
                            PrintAnimal(animalType, cat);
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new(tokens[0], int.Parse(tokens[1]));
                            PrintAnimal(animalType, tomcat);
                            break;
                        case "Kitten":
                            Kitten kitten = new(tokens[0], int.Parse(tokens[1]));
                            PrintAnimal(animalType, kitten);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void PrintAnimal<T>(string animalType, T animal) where T : Animal
        {
            Console.WriteLine(animalType);
            Console.WriteLine(animal.ToString());
        }
    }
}
