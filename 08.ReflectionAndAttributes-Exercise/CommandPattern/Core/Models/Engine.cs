using System;


namespace CommandPattern.Core.Models
{
    using Contracts;
  public  class Engine:IEngine
  {
      private  ICommandInterpreter _commandInterpreter;
      public Engine(ICommandInterpreter commandInterpreter)
        {
            _commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            while (true)
            {
                string command = Console.ReadLine();
                string result= _commandInterpreter.Read(command);
                if (result == null)
                {
                    break;
                }
                Console.WriteLine(result);
            }
          
        }
    }
}
