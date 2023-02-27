using System;
using System.Collections.Generic;

namespace PizzaCallories.Models;

public class Dough
{
    private const double BaseDoughCaloriesPerGram = 2;
    private readonly Dictionary<string, double> flourTypesCalories;
    private readonly Dictionary<string, double> bakingTechniquesCalories;

    private string flourType;
    private string bakingTechnique;
    private double weight;

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        flourTypesCalories =
            new Dictionary<string, double> { { "white", 1.5 }, { "wholegrain", 1.0 } };

        bakingTechniquesCalories =
            new Dictionary<string, double> { { "crispy", 0.9 }, { "chewy", 1.1 }, { "homemade", 1.0 } };

        FlourType = flourType;
        BakingTechnique = bakingTechnique;
        Weight = weight;
    }

    public double Weight
    {
        get => weight;
        private set
        {
            if (value < 0 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }

            weight = value;
        }
    }

    public string FlourType
    {
        get => flourType;
        private set
        {
            if (!flourTypesCalories.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            flourType = value.ToLower();
        }
    }

    public string BakingTechnique
    {
        get => bakingTechnique;
        private set
        {
            if (!bakingTechniquesCalories.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            bakingTechnique = value.ToLower();
        }
    }

    public double Calories
    {
        get
        {
            double flourTypeModifier = bakingTechniquesCalories[BakingTechnique];
            double techniqueModifier = flourTypesCalories[FlourType];

            return BaseDoughCaloriesPerGram * weight * flourTypeModifier * techniqueModifier;
        }
    }
}
