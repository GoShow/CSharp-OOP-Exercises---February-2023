using LogForU.Core.Layouts.Interfaces;
using System.Text;

namespace LogForU.ConsoleApp.CustomLayouts;

public class XmlLayout : ILayout
{
    public string Format
    {
        get
        {
            StringBuilder sb = new();
            sb.AppendLine("<log>");
            sb.AppendLine("\t<date>{0}</date>");
            sb.AppendLine("\t<level>{1}</level>");
            sb.AppendLine("\t<message>{2}</message>");
            sb.AppendLine("</log>");

            return sb.ToString();
        }
    }
}
