using System;
using System.Collections.Generic;
using System.Text;
using LoggerLibrary.Enumerations;
using LoggerLibrary.interfaces;

namespace LoggerLibrary.Appenders
{
    using interfaces;
    public class FileAppender : IAppender
    {
        private ILayout layout;
        private ILogFile file;

        public FileAppender(ILayout layout, ILogFile file)
        {
            this.layout = layout;
            this.file = file;
        }

        public void Append(string date, ReportLevelEnum reportLevel, string message)
        {
            string content = string.Format(this.layout.Template, date, reportLevel, message);
            this.file.Write(content);
        }
    }
}
