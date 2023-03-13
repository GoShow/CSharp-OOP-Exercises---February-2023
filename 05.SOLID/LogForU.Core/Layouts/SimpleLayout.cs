using LogForU.Core.Layouts.Interfaces;

namespace LogForU.Core.Layouts;

public class SimpleLayout : ILayout
{
    private const string SimpleFormat = "{0} - {1} - {2}";

    public string Format => SimpleFormat;
}
