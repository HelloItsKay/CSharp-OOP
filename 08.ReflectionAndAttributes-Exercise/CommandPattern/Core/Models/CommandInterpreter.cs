using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Models.Commands;
using Microsoft.VisualBasic.CompilerServices;


namespace CommandPattern.Core.Models
{
    using Contracts;
    public class CommandInterpreter : ICommandInterpreter
    {
        private  const string _commandSuffix="Command";
        public string Read(string args)
        {
            string[] tokens = args.Split();
            string commandName = tokens[0];
            string[] commandArgs = tokens[1..];
             

            Type commandType = Assembly
                         .GetCallingAssembly()
                         .GetTypes()
                         .FirstOrDefault(x => x.Name == $"{commandName}{_commandSuffix}");

            ICommand command = (ICommand)Activator.CreateInstance(commandType);
             
            string result = command.Execute(commandArgs);
            return result;
        }
    }
}
