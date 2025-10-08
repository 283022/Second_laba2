namespace Second_laba.Logger;

public class Logger
{
    private readonly FileInfo _logFile = new("D:/log.txt");

    public void Log(string message)
    {
        using var writer = _logFile.AppendText();
        writer.WriteLine(message);
    }
    
    
}