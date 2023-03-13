using LogForU.ConsoleApp.CustomLayouts;
using LogForU.ConsoleApp.Factories.Interfaces;
using LogForU.Core.Layouts;
using LogForU.Core.Layouts.Interfaces;
using System;

namespace LogForU.ConsoleApp.Factories;

public class LayoutFactory : ILayoutFactory
{
    public ILayout CreateLayout(string type)
    {
        switch (type)
        {
            case "SimpleLayout": return new SimpleLayout();
            case "XmlLayout": return new XmlLayout();
            default: throw new InvalidOperationException("Invalid layout type");
        }
    }
}
