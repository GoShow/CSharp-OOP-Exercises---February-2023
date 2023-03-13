using LogForU.ConsoleApp.Factories.Interfaces;
using LogForU.Core.Appenders;
using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.Enums;
using LogForU.Core.IO.Interfaces;
using LogForU.Core.Layouts.Interfaces;
using System;

namespace LogForU.ConsoleApp.Factories;

public class AppenderFactory : IAppenderFactory
{
    public IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel = 0, ILogFile logFile = null)
    {
        switch (type)
        {
            case "ConsoleAppender": return new ConsoleAppender(layout, reportLevel);
            case "FileAppender": return new FileAppender(layout, logFile, reportLevel);
            default: throw new InvalidOperationException("Invalid appender type");
        }
    }
}
