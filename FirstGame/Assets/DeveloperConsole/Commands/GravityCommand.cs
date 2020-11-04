using UnityEngine;

namespace Console
{
    public class GravityCommand : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public GravityCommand()
        {
            Name = "Gravity";
            Command = "gravity";
            Description = "Sets gravity to floating args.";
            Help = "gravity -9.8";

            AddCommandConsole();
        }

        public override void RunCommand(string[] args)
        {
            if (!float.TryParse(args[0], out float value))
            {
                Debug.LogWarning(args[0] + " is not a floating number.");
                return;
            }
            Physics.gravity = new Vector3(Physics.gravity.x, float.Parse(args[0]), Physics.gravity.z);
            Debug.Log("Gravity was set to value " + args[0] + ".");
        }

        public static GravityCommand CreateCommand()
        {
            return new GravityCommand();
        }
    }

}