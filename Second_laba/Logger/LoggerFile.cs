using Second_laba.Logger.Interfaces;

namespace Second_laba.Logger;

public class LoggerFile: ILoggerWriter, ILoggerStorage
{
    public LoggerFile(string startFilePath)
    {
        if (string.IsNullOrEmpty(startFilePath))
        {
            _filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SecondLaba\log.txt";
            GenerateFileByPath();
            return;
        }
        _filePath = startFilePath;
        FileFound();
    }
    
    private string _filePath;
   
    public void Log(string message)
    {
        if (string.IsNullOrEmpty(message)) return;
        if (!CheckExistance(_filePath))
            throw new FileNotFoundException($"File {_filePath} not found");
        File.AppendAllText(_filePath, message + Environment.NewLine);
        
    }

    private void FileFound()
    {
        if (CheckExistance(_filePath)) return;
        Console.WriteLine($"Now Logging File isn't exist: {_filePath} \n generate a new file?(y/n): ");
        var s = Console.ReadLine();
        if (s == "y" || s == null)
        {
            GenerateFileByPath();
        }
        else
        {
            throw new FileNotFoundException($"File {_filePath} not found");
        }
    }
    public bool CheckExistance(string filePath)
    {
        return File.Exists(filePath);
        
    }
    public void AddNewFilePath(string filePath)
    {
        _filePath = filePath;
    }
    public bool GenerateFileByPath()
    {
        if (!File.Exists(_filePath))
        {
            File.Create(_filePath);
            return true;
        }
        else
        {
            return false;
        }
    }
}