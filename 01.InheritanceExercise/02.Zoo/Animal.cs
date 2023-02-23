namespace Zoo;

public abstract class Animal
{
    public Animal(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
