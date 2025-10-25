using Game.Logger.Interfaces;

namespace Game.Logger;

public class LoggerConsole(Action<string> logAction) : ILoggerWriter
{
    public void Log(string message)
    {
        logAction(message);
    }
}