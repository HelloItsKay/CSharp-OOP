
using LoggerLibrary.Enumerations;

namespace LoggerLibrary.interfaces
{
   public interface IAppender
   {
       public void Append(string date, ReportLevelEnum reportLevel, string message);
   }
}
