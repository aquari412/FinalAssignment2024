using System;
using System.IO;

class Section04
{
    private static readonly string LogDir = "log";
    private static readonly string LogFileName = "execution.log";
    private static readonly string LogFilePath = Path.Combine(LogDir, LogFileName);

    static void Main(string[] args)
    {
        try
        {
            InitializeLogDirectory();
            WriteLog("Program started.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void InitializeLogDirectory()
    {
        if (!Directory.Exists(LogDir))
        {
            Directory.CreateDirectory(LogDir);
        }
        else
        {
            // フォルダが既に存在する場合は、そのままにしておく
            Console.WriteLine("Log directory already exists.");
        }
    }

    private static void WriteLog(string message)
    {
        using (StreamWriter writer = new StreamWriter(LogFilePath, true))
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            writer.WriteLine($"{timestamp} - {message}");
        }
    }
}