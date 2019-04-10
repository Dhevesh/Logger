using System;
using System.IO;
using System.Linq;

namespace Logger
{
    internal class LogToFile
    {
        readonly string filePath = @"c:\TestLogs\";

        internal void CheckDirectory()
        {
            if (Directory.Exists(filePath))
            {
                Console.WriteLine("Directory Exists!");
            }
            else
            {
                Directory.CreateDirectory(filePath);
                Console.WriteLine("Directory created");
            }
        }
        //Takes in the error exception as an input
        internal void InfoLog(string e)
        {
            string _date = $"{DateTime.Now:yyyyMMdd}";
            string _time = $"{DateTime.Now.ToShortTimeString()} [INFO]";
            string _file = $"{filePath}log_{_date}.txt";
            if (!Directory.EnumerateFileSystemEntries(filePath).Any())
            {
                using (var _fileStream = new StreamWriter(_file, true))
                {
                    _fileStream.WriteLine($"{_time} {e}");
                }
                
            }
            else
            {
                if (File.Exists(_file))
                {
                    using (var _fileStream = new StreamWriter(_file, true))
                    {
                        _fileStream.WriteLine($"{_time} {e}");
                    }
                    
                }
                else
                {
                    using (var _fileStream = new StreamWriter(_file, true))
                    {
                        _fileStream.WriteLine($"{_time} {e}");
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LogToFile _LogToFile = new LogToFile();
            _LogToFile.CheckDirectory();
            try
            {
                Console.Write("Enter a number");
                string number = Console.ReadLine();
                int stringToInt = int.Parse(number);
            }
            catch (Exception e)
            {
                _LogToFile.InfoLog(e.ToString());
            }
        }
    }
}
