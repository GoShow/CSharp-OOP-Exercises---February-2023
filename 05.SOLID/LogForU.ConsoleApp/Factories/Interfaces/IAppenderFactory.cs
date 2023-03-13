using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.Enums;
using LogForU.Core.IO.Interfaces;
using LogForU.Core.Layouts.Interfaces;

namespace LogForU.ConsoleApp.Factories.Interfaces;

public interface IAppenderFactory
{
    IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel, ILogFile logFile = null);
}
