using LoggerLibrary.Appenders;
using LoggerLibrary.Enumerations;

namespace LoggerLibrary.Loggers
{
    using LoggerLibrary.interfaces;
    class Logger:ILogger
    {
        private IAppender[] appender;
        private ILogFile file;

        public Logger(params IAppender[] appender)
        {
            this.appender = appender;
        }

      
            

        public void Info(string date, string masage)
        {
            foreach (IAppender appender in this.appender)
            {
                 appender.Append(date,ReportLevelEnum.Info,masage);
            }
           
        }

        public void Error(string date, string masage)
        {
            foreach (IAppender appender in this.appender)
            {
                appender.Append(date, ReportLevelEnum.Error, masage);
            }
        }


    }
}
