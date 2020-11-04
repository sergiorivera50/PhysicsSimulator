using UnityEngine;

namespace Console
{
    public class HelpCommand : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public HelpCommand()
        {
            Name = "Help";
            Command = "help";
            Description = "Prints all commands and its usage to console.";
            Help = "help";

            AddCommandConsole();
        }

        public override void RunCommand(string[] args)
        {
            foreach (var command in DeveloperConsole.Commands)
            {
                string str = command.Value.Command + " - " + command.Value.Description + " (example: " + command.Value.Help + ")";
                DeveloperConsole.AddStaticMessageToConsole(str, ignoreWarning: true);
            }
        }
        
        public static HelpCommand CreateCommand()
        {
            return new HelpCommand();
        }
    }

}