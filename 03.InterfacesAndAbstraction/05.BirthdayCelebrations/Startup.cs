using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;

List<IBirthable> society = new();

while (true)
{
    string input = Console.ReadLine();

    if (input == "End")
    {
        break;
    }

    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string command = tokens[0];

    switch (command)
    {
        case "Citizen":
            IBirthable citizen = new Citizen(tokens[3], tokens[1], int.Parse(tokens[2]), tokens[4]);
            society.Add(citizen);
            break;
        case "Pet":
            IBirthable pet = new Pet(tokens[1], tokens[2]);
            society.Add(pet);
            break;
    }
}

string year = Console.ReadLine();

foreach (var element in society)
{
    if (element.Birthdate.EndsWith(year))
    {
        Console.WriteLine(element.Birthdate);
    }
}