using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.IO;

namespace PrincipeInversionDependance
{
    public class Terminal
    {
        public bool Exited { get; set; }
        private string _promptString;

        public Terminal()
        {
            _promptString = String.Format("{0}$ ", System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            Exited = false;
        }

        public string Prompt()
        {
            Console.Write(_promptString);
            string userCommand = Console.ReadLine();
            return userCommand;
        }

        public Interface1 PromptCommand()
        {
            string commandLine = Prompt();
            return new Command(commandLine);
        }


        public void ExecuteCommand(Interface1 command)
        {
            try
            {
                command.Launch();
                if (command.Output.Length > 0)
                {
                    Console.WriteLine(command.Output);
                }
            }
            catch (InvalidOperationException exception)
            {
                Console.Error.WriteLine("{0}: path not found", command, exception);
            }
        }
    }
}
