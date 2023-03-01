using CollectionHierarchy.Core.Interfaces;
using CollectionHierarchy.Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;

namespace CollectionHierarchy.Core;

public class Engine : IEngine
{
    public void Run()
    {
        Dictionary<string, List<int>> addedIndexes = new()
            {
                { "AddCollection", new List<int>() },
                { "AddRemoveCollection", new List<int>() },
                { "MyList", new List<int>() }
            };

        Dictionary<string, List<string>> removedItems = new()
            {
                { "AddCollection", new List<string>() },
                { "AddRemoveCollection", new List<string>() },
                { "MyList", new List<string>() }
            };

        IAddCollection addCollection = new AddCollection();
        IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
        IMyList myList = new MyList();

        string[] items = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        foreach (var item in items)
        {
            addedIndexes["AddCollection"].Add(addCollection.Add(item));

            addedIndexes["AddRemoveCollection"].Add(addRemoveCollection.Add(item));

            addedIndexes["MyList"].Add(myList.Add(item));
        }

        int removeCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < removeCount; i++)
        {
            removedItems["AddRemoveCollection"].Add(addRemoveCollection.Remove());
            removedItems["MyList"].Add(myList.Remove());
        }

        Console.WriteLine(string.Join(" ", addedIndexes["AddCollection"]));
        Console.WriteLine(string.Join(" ", addedIndexes["AddRemoveCollection"]));
        Console.WriteLine(string.Join(" ", addedIndexes["MyList"]));

        Console.WriteLine(string.Join(" ", removedItems["AddRemoveCollection"]));
        Console.WriteLine(string.Join(" ", removedItems["MyList"]));
    }
}
