using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.DeveloperConsole.Commands
{
    public interface IConsoleCommand
    {
        string CommandWord { get; }
        bool Process(string[] args);
    }

    public abstract class ConsoleCommand : ScriptableObject, IConsoleCommand
    {
        [SerializeField] private string commandWord = string.Empty;
        public string CommandWord => commandWord;
        public abstract bool Process(string[] args);
    }
}

