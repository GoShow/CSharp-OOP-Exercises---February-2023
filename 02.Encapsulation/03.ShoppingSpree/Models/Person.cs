using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree.Models;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> products;

    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
        products = new List<Product>();
    }

    public string Name
    {
        get => name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.NameExceptionMessage);
            }

            name = value;
        }
    }

    public decimal Money
    {
        get => money;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.MoneyExeptionMessage);
            }

            money = value;
        }
    }

    public string Add(Product product)
    {
        if (Money < product.Cost)
        {
            return $"{Name} can't afford {product}";
        }

        products.Add(product);

        Money -= product.Cost;

        return $"{Name} bought {product}";
    }

    public override string ToString()
    {
        string productsString = products.Any()
             ? string.Join(", ", products)
             : "Nothing bought";

        return $"{Name} - {productsString}";
    }
}
