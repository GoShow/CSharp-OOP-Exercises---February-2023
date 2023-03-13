using LogForU.ConsoleApp.Core.Interfaces;
using LogForU.ConsoleApp.Factories;
using LogForU.ConsoleApp.Factories.Interfaces;
using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.Enums;
using LogForU.Core.IO;
using LogForU.Core.IO.Interfaces;
using LogForU.Core.Layouts.Interfaces;
using LogForU.Core.Loggers;
using LogForU.Core.Loggers.Interfaces;
using System;
using System.Collections.Generic;

namespace LogForU.ConsoleApp.Core;

public class Engine : IEngine
{
    private readonly ILayoutFactory layoutFactory;
    private readonly IAppenderFactory appenderFactory;

    private readonly ICollection<IAppender> appenders;
    private ILogger logger;

    public Engine()
    {
        appenders = new HashSet<IAppender>();

        layoutFactory = new LayoutFactory();
        appenderFactory = new AppenderFactory();
    }

    public void Run()
    {
        CreateAppenders();

        logger = new Logger(appenders);

        LogMessages();

        Console.WriteLine("Logger info");
        Console.WriteLine(string.Join(Environment.NewLine, appenders));
    }

    private void CreateAppenders()
    {
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            try
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string appenderType = tokens[0];
                string layoutType = tokens[1];

                ILayout layout = layoutFactory.CreateLayout(layoutType);

                ReportLevel reportLevel = ReportLevel.Info;

                if (tokens.Length == 3)
                {
                    bool isReportLevelValid = Enum.TryParse<ReportLevel>(tokens[2], true, out reportLevel);
                    if (!isReportLevelValid)
                    {
                        throw new InvalidOperationException("Report level is not valid!");
                    }
                }

                IAppender appender;
                if (appenderType == "FileAppender")
                {
                    ILogFile logFile = new LogFile("log", "xml", "../../../Logs");

                    appender = appenderFactory.CreateAppender(appenderType, layout, reportLevel, logFile);
                }
                else
                {
                    appender = appenderFactory.CreateAppender(appenderType, layout, reportLevel);
                }

                appenders.Add(appender);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    private void LogMessages()
    {
        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] tokens = command
                .Split("|", StringSplitOptions.RemoveEmptyEntries);
            string reportLevelStr = tokens[0];
            string dateTime = tokens[1];
            string message = tokens[2];

            try
            {
                switch (reportLevelStr)
                {
                    case "INFO":
                        logger.Info(dateTime, message);
                        break;
                    case "WARNING":
                        logger.Warning(dateTime, message);
                        break;
                    case "ERROR":
                        logger.Error(dateTime, message);
                        break;
                    case "CRITICAL":
                        logger.Critical(dateTime, message);
                        break;
                    case "FATAL":
                        logger.Fatal(dateTime, message);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }


    //For testing purposes
    //public void Run()
    //{
    //    SimpleLayout simpleLayout = new();
    //    ConsoleAppender consoleAppender = new(simpleLayout);
    //    consoleAppender.ReportLevel = ReportLevel.Error;

    //    var logger = new Logger.Core.Loggers.Logger(consoleAppender);

    //    logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");

    //    DateTimeValidator.AddFormat("dd/MM/yyyy");

    //    logger.Fatal("31/01/2015", "Warning: ping is too high - disconnect imminent");

    //    logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
    //}
}