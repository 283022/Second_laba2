namespace Second_laba.Logger.Interfaces;

public interface ILoggerStorage
{
    public void AddNewFilePath(string filePath);
    public bool GenerateFileByPath();
    public bool CheckExistance(string filePath);
}