using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core;

public class CommandInterpreter : ICommandInterpreter
{
    public string Read(string args)
    {
        string[] arguments = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string commandName = arguments[0];

        string[] commandArguments = arguments.Skip(1).ToArray();

        Type commandType = Assembly
            .GetEntryAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == $"{commandName}Command");

        if (commandType is null)
        {
            throw new InvalidOperationException("Command not found.");
        }

        ICommand commandInstance =
            Activator.CreateInstance(commandType) as ICommand;

        string result = commandInstance.Execute(commandArguments);

        //Get method with reflection and invoke. Alternative to string result = commandInstance.Execute(commandArguments);
        //MethodInfo executeMethod = typeof(ICommand).GetMethod("Execute");
        //object result = executeMethod.Invoke(commandInstance, new object[] { commandArguments });

        return result.ToString();
    }
}
