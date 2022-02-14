using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace LoggerLibrary.Loggers
{
    using System.Linq;
    using interfaces;
    using System.IO;
    public class LogFile : ILogFile
    {
        public string filePath = "log.txt";
        public int Size => File.ReadAllText(filePath).Where(x => char.IsLetter(x)).Sum(x => x);
        public void Write(string message)
        {
            
            File.WriteAllText(filePath, message);
        }


    }
}
