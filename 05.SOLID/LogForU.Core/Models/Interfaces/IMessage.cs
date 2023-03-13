using LogForU.Core.Enums;

namespace LogForU.Core.Models.Interfaces;

public interface IMessage
{
    string CreatedTime { get; }
    string Text { get; }
    ReportLevel ReportLevel { get; }
}
