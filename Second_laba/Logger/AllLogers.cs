using Second_laba.Logger.Interfaces;

namespace Second_laba.Logger;

public class AllLogers
{
    private readonly ILoggerWriter[] _logs = new ILoggerWriter[]
    {
        new LoggerFile("log.txt"),
        new LoggerConsole()
    };

    public void Log(string message)
    {
        foreach (var logWrite in _logs)
        {
            logWrite.Log(message);
        }
    }
}