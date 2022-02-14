using System;
using System.Collections.Generic;
using System.Text;

using LoggerLibrary.Enumerations;

namespace LoggerLibrary.interfaces
{
    using LoggerLibrary.interfaces;
 public   class ConsoleAppender:IAppender
 {
     private ILayout layout;
        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
        }


        public void Append(string date, ReportLevelEnum reportLevel, string message)
        {
            string content = string.Format(this.layout.Template, date,reportLevel,message);
            Console.WriteLine(content);
        }
    }
}
