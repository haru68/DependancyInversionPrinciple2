using System;
using System.Diagnostics;
using System.Linq;
using System.IO;

namespace PrincipeInversionDependance
{
    public class Program
    {
        public static void Main()
        {
            Terminal terminal = new Terminal();
            while (!terminal.Exited)
            {
                Interface1 command = terminal.PromptCommand();
                terminal.ExecuteCommand(command);
            }
        }
    }
}



