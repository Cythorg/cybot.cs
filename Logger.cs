using System;
using System.Collections.Generic;
using System.Text;

namespace Cybot
{
    public enum LogType { Error, Warn, Info, Debug, Trace}
    public static class Logger
    {
        public static void Log(object sender, string message, LogType logType = LogType.Trace)
        {
            switch (logType)
            {
                case LogType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogType.Warn:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case LogType.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogType.Debug:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case LogType.Trace:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                default:
                    break;
            }
            Console.Write($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss zzz")}] [{sender.GetType().Name}] [{logType}] ");
            Console.ResetColor();
            Console.Write($"{message}\n");
        }
    }
}
