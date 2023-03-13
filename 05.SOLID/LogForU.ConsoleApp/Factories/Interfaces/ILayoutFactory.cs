using LogForU.Core.Layouts.Interfaces;

namespace LogForU.ConsoleApp.Factories.Interfaces;

public interface ILayoutFactory
{
    ILayout CreateLayout(string type);
}
