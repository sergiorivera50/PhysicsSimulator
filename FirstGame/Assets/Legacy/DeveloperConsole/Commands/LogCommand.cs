using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.DeveloperConsole.Commands
{
    [CreateAssetMenu(fileName = "New Log Command", menuName = "Assets/DeveloperConsole/Commands/Log Command")]
    public class LogCommand : ConsoleCommand
    {
        public override bool Process(string[] args)
        {
            string logText = string.Join(" ", args);

            Debug.Log(logText);
            return true;
        }
    }
}
