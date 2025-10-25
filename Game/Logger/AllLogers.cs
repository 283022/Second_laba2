using Game.Logger.Interfaces;

namespace Game.Logger;

public class AllLogers(ILoggerWriter[] list ): ILoggerWriter
{
    public void Log(string message)
    {
        foreach (var logWrite in list)
        {
            logWrite.Log(message);
        }
    }

    public void LogWithOutConsole(string message)
    {
        foreach (var logWrite in list)
        {
            if (logWrite is LoggerConsole)
            {
                continue;
            }
            
            logWrite.Log(message);
        }
    }
}