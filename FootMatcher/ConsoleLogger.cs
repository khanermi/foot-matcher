﻿namespace FootMatcher
{
    public class ConsoleLogger : IConsoleLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}