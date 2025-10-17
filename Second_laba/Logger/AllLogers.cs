using Second_laba.Logger.Interfaces;

namespace Second_laba.Logger;

public class AllLogers(ILoggerWriter[] list ): ILoggerWriter
{
    public void Log(string message)
    {
        foreach (var logWrite in list)
        {
            logWrite.Log(message);
        }
    }
}