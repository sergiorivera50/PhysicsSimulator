using System;
using UnityEngine;

namespace Console
{
    public class PlayerMassCommand : ConsoleCommand
    {
        public override string Name { get; protected set; }
        public override string Command { get; protected set; }
        public override string Description { get; protected set; }
        public override string Help { get; protected set; }

        public PlayerMassCommand()
        {
            Name = "PlayerMass";
            Command = "playerMass";
            Description = "Sets player mass to floating argument.";
            Help = "playerMass 20";

            AddCommandConsole();
        }

        public override void RunCommand(string[] args)
        {
            float newMass = float.Parse(args[0]);
            if (newMass <= 0)
            {
                Debug.LogWarning("Player mass cannot be <= 0!");
                return;
            }
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Rigidbody>().mass = newMass;
            Debug.Log("Player mass attribute was set " + args[0] + ".");
        }

        public static PlayerMassCommand CreateCommand()
        {
            return new PlayerMassCommand();
        }
    }

}