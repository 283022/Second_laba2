using Second_laba.Logger.Interfaces;

namespace Second_laba.Logger;


public class LoggerConsole(Action<string> logAction) : ILoggerWriter
{
    public void Log(string message)
    {
        logAction(message);
    }
    
}