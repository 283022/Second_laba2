using Second_laba.Logger.Interfaces;

namespace Second_laba.Logger;


public class LoggerConsole : ILoggerWriter
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}