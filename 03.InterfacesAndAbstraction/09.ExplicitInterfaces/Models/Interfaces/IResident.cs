﻿namespace ExplicitInterfaces.Models.Interfaces;

public interface IResident
{
    string Name { get; }

    string Country { get; }

    string GetName();
}
