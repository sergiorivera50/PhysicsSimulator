using System.Linq;
using UnityEngine;

namespace Console
{
    public class ClearCommand : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public ClearCommand()
        {
            Name = "Clear";
            Command = "clear";
            Description = "Clears the screen of the console.";
            Help = "clear";

            AddCommandConsole();
        }

        public override void RunCommand(string[] args)
        {
            DeveloperConsole.Instance.consoleText.text = "";
        }

        public static ClearCommand CreateCommand()
        {
            return new ClearCommand();
        }
    }

}