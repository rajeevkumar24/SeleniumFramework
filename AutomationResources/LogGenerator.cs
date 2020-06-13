using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumFramework
{
    public class LogGenerator
    {
        public void LogInit()
        {
            Log.Logger = new LoggerConfiguration()
                 .MinimumLevel.Debug()
                 .WriteTo.Console()
                 .WriteTo.File("C:\\AutomationTools\\LogFile.txt", outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}", rollingInterval: RollingInterval.Day)
                  .CreateLogger();
            Log.Information("Log creation started");

        }
        public void LogClose()
        {
            Log.CloseAndFlush();
        }
    }
}
