using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator.Models;

public class Team
{
    private string name;
    private readonly List<Player> players;

    public Team(string name)
    {
        Name = name;
        players = new List<Player>();
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            name = value;
        }
    }

    public double Rating
    {
        get
        {
            if (players.Any())
            {
                return players.Average(p => p.Stats);
            }

            return 0;
        }
    }

    public void AddPlayer(Player player) => players.Add(player);

    public void RemovePlayer(string playerName)
    {
        Player player = players.FirstOrDefault(p => p.Name == playerName);

        if (player == null)
        {
            throw new ArgumentException($"Player {playerName} is not in {Name} team.");
        }

        players.Remove(player);
    }
}
