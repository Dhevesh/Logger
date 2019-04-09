using System;
using System.IO;

namespace Logger
{
    internal class LogToFile
    {
        internal void CheckDirectory(string filePath)
        {
            if (Directory.Exists(filePath))
            {
                Console.WriteLine("Directory Exists!");
                File.Create(filePath);
            }
            else
            {
                Directory.CreateDirectory(filePath);
                Console.WriteLine("Directory created");
            }
        }
        internal void InfoLog()
        {
            string filePath = @"C:\TestLogs";
            try
            {
                CheckDirectory(filePath);
                string[] files = Directory.GetFiles(filePath);
                foreach (string _files in files)
                {
                    if (string.IsNullOrEmpty(_files))
                    {
                        Console.WriteLine("No files found at the specified location");
                    }
                    else
                    {
                        Console.WriteLine($"File found {_files}");
                    }
                }
            }
            catch (DirectoryNotFoundException)
            {

            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LogToFile _LogToFile = new LogToFile();
            _LogToFile.InfoLog();
            
        }
    }
}
