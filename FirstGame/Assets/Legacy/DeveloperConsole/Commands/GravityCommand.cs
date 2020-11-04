using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.DeveloperConsole.Commands
{
    [CreateAssetMenu(fileName = "New Gravity Command", menuName = "Assets/DeveloperConsole/Commands/Gravity Command")]
    public class GravityCommand : ConsoleCommand
    {
        public override bool Process(string[] args)
        {
            if (args.Length != 1) return false;
            if (!float.TryParse(args[0], out float value)) return false; // if it's not a float

            Physics.gravity = new Vector3(Physics.gravity.x, value, Physics.gravity.z);
            return true;
        }
    }
}
