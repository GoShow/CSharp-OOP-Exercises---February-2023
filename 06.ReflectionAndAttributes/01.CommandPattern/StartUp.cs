namespace CommandPattern;

using Core;
using Core.Contracts;

public class StartUp
{
    public static void Main()
    {
        ICommandInterpreter commandInterpeter = new CommandInterpreter();

        IEngine engine = new Engine(commandInterpeter);

        engine.Run();
    }
}
