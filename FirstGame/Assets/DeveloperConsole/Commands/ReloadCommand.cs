using UnityEngine;
using UnityEngine.SceneManagement;

namespace Console
{
    public class ReloadCommand : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public ReloadCommand()
        {
            Name = "Reload";
            Command = "reload";
            Description = "Reloads active scene.";
            Help = "reload";

            AddCommandConsole();
        }

        public override void RunCommand(string[] args)
        {
            Debug.Log("Reloading current scene...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public static ReloadCommand CreateCommand()
        {
            return new ReloadCommand();
        }
    }

}

