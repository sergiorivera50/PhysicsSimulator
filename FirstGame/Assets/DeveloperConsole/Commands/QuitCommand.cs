using UnityEngine;

namespace Console
{
    public class QuitCommand : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public QuitCommand()
        {
            Name = "Quit";
            Command = "quit";
            Description = "Quits the application.";
            Help = "quit";

            AddCommandConsole();
        }

        public override void RunCommand(string[] args)
        {
            Debug.Log("Quitting application...");
            if (Application.isEditor)
            {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
            }
            else
            {
                Application.Quit();
            }
        }

        public static QuitCommand CreateCommand()
        {
            return new QuitCommand();
        }
    }

}