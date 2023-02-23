using System;

namespace Animals;

public abstract class Animal
{
    private string name;

    private int age;

    private string gender;

    public Animal(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    public string Name
    {
        get
        {
            return name;
        }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid input!");
            }

            name = value;
        }
    }

    public int Age
    {
        get
        {
            return age;
        }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Invalid input!");
            }

            age = value;
        }
    }

    public string Gender
    {
        get
        {
            return gender;
        }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid input!");
            }

            gender = value;
        }
    }

    public abstract string ProduceSound();

    public override string ToString()
        => $"{Name} {Age} {Gender}{Environment.NewLine}{ProduceSound()}";
}
