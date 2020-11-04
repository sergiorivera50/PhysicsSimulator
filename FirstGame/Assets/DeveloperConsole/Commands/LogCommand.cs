using System.Linq;
using UnityEngine;

namespace Console
{
    public class LogCommand : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public LogCommand()
        {
            Name = "Log";
            Command = "log";
            Description = "Logs a message to the console.";
            Help = "log Hello World";

            AddCommandConsole();
        }

        public override void RunCommand(string[] args)
        {
            Debug.Log(string.Join(" ", args));
        }

        public static LogCommand CreateCommand()
        {
            return new LogCommand();
        }
    }

}