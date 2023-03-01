using BorderControl.Models;
using BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;

List<IIdentifiable> society = new();

while (true)
{
    string input = Console.ReadLine();

    if (input == "End")
    {
        break;
    }

    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (tokens.Length == 3)
    {
        IIdentifiable citizen = new Citizen(tokens[2], tokens[0], int.Parse(tokens[1]));
        society.Add(citizen);
    }
    else
    {
        IIdentifiable robot = new Robot(tokens[1], tokens[0]);
        society.Add(robot);
    }
}

string invalidIdSuffix = Console.ReadLine();

foreach (var element in society)
{
    if (element.Id.EndsWith(invalidIdSuffix))
    {
        Console.WriteLine(element.Id);
    }
}
