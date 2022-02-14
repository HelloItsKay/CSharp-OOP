using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerLibrary.interfaces
{
  public  interface ILogFile
    {
        public void Write(string message);
        public int Size { get; }
    }
}
