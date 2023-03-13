using System;
using System.Collections.Generic;
using System.Globalization;

namespace LogForU.Core.Utils;

public static class DateTimeValidator
{
    private static readonly ISet<string> formats = new HashSet<string> { "M/dd/yyyy h:mm:ss tt" };

    public static void AddFormat(string format)
        => formats.Add(format);

    internal static bool ValidateDateTime(string createdTime)
    {
        foreach (var format in formats)
        {
            if (DateTime.TryParseExact(createdTime, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
            {
                return true;
            }
        }

        return false;
    }
}
