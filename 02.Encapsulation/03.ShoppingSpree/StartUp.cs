using ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;

List<Person> people = new();
List<Product> products = new();


try
{
    string[] nameMoneyPairs = Console.ReadLine()
        .Split(";", StringSplitOptions.RemoveEmptyEntries);

    foreach (var nameMoneyPair in nameMoneyPairs)
    {
        string[] nameMoney = nameMoneyPair
            .Split("=", StringSplitOptions.RemoveEmptyEntries);

        Person person = new(nameMoney[0], decimal.Parse(nameMoney[1]));

        people.Add(person);
    }

    string[] productCostPairs = Console.ReadLine()
        .Split(";", StringSplitOptions.RemoveEmptyEntries);

    foreach (var productCostPair in productCostPairs)
    {
        string[] productCost = productCostPair
            .Split("=", StringSplitOptions.RemoveEmptyEntries);

        Product product = new(productCost[0], decimal.Parse(productCost[1]));

        products.Add(product);
    }
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);

    return;
}

string input;
while ((input = Console.ReadLine()) != "END")
{
    string[] personProduct = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string personName = personProduct[0];
    string productName = personProduct[1];

    Person person = people.FirstOrDefault(p => p.Name == personName);
    Product product = products.FirstOrDefault(p => p.Name == productName);

    if (person is not null && product is not null)
    {
        Console.WriteLine(person.Add(product));
    }
}

Console.WriteLine(string.Join(Environment.NewLine, people));
