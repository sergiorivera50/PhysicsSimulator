using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

namespace Console
{
    public abstract class ConsoleCommand
    {
        public abstract string Name { get; protected set; }
        public abstract string Command { get; protected set; }
        public abstract string Description { get; protected set; }
        public abstract string Help { get; protected set; }

        public void AddCommandConsole()
        {
            string addMessage = " command has been added to the console.";

            DeveloperConsole.AddCommandsToConsole(Command, this);
            Debug.Log(Name + addMessage);
        }

        public abstract void RunCommand(string[] args);
    }
    
    public class DeveloperConsole : MonoBehaviour
    {
        public static DeveloperConsole Instance { get; private set; }
        public static Dictionary<string, ConsoleCommand> Commands { get; private set; }

        [Header("UI Components")]
        public Canvas consoleCanvas;
        public ScrollRect scrollRect;
        public Text consoleText;
        public TMP_InputField inputText;

        private void Awake()
        {
            if (Instance != null) return;
            Instance = this;
            Commands = new Dictionary<string, ConsoleCommand>();
        }

        private void Start()
        {
            consoleCanvas.gameObject.SetActive(false);
            CreateCommands();
        }

        private void OnEnable()
        {
            Application.logMessageReceived += HandleLog;    
        }

        private void OnDisable()
        {
            Application.logMessageReceived -= HandleLog;
        }

        private void HandleLog(string logMessage, string stackTrace, LogType type)
        {
            string _message = "[" + type.ToString() + "] " + logMessage;
            AddMessageToConsole(_message);
        }

        private void CreateCommands()
        {
            QuitCommand quitCommand = QuitCommand.CreateCommand();
            GravityCommand gravityCommand = GravityCommand.CreateCommand();
            ReloadCommand reloadCommand = ReloadCommand.CreateCommand();
            HelpCommand helpCommand = HelpCommand.CreateCommand();
            PlayerMassCommand playerMassCommand = PlayerMassCommand.CreateCommand();
            LogCommand logCommand = LogCommand.CreateCommand();
            ClearCommand clearCommand = ClearCommand.CreateCommand();
        }

        public static void AddCommandsToConsole(string _name, ConsoleCommand _command)
        {
            if (!Commands.ContainsKey(_name)) {
                Commands.Add(_name, _command);
            }
        }

        private float pausedTimeScale;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (consoleCanvas.gameObject.activeSelf)
                {
                    Time.timeScale = pausedTimeScale;
                    consoleCanvas.gameObject.SetActive(false);
                    inputText.text = "";
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;

                } 
                else
                {
                    pausedTimeScale = Time.timeScale;
                    consoleCanvas.gameObject.SetActive(true);
                    inputText.ActivateInputField(); // it will activate input field without having to click
                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = true;
                }
            }

            if (consoleCanvas.gameObject.activeInHierarchy)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    // Check if input is empty
                    if (inputText.text != "")
                    {
                        inputText.ActivateInputField();
                        AddMessageToConsole("> " + inputText.text);
                        ParseInput(inputText.text);
                        inputText.text = string.Empty;
                    }
                }
            }
        }

        // Adding messages to console from this class
        private void AddMessageToConsole(string msg)
        {
            consoleText.text += msg + "\n";
            scrollRect.verticalNormalizedPosition = 0f;
        }

        // Adding messages to console from outside objects/classes
        public static void AddStaticMessageToConsole(string msg, bool ignoreWarning=false)
        {
            if (!ignoreWarning) Debug.LogWarning("Debug.Log() should be used instead of AddStaticMessageToConsole()");
            DeveloperConsole.Instance.consoleText.text += msg + "\n";
            DeveloperConsole.Instance.scrollRect.verticalNormalizedPosition = 0f;
        }

        private void ParseInput(string input)
        {
            string[] _input = input.Split(null);

            // No input
            if (_input.Length == 0 || _input == null)
            {
                Debug.LogWarning("Unknown command.");
                return;
            }

            // Command not recognized
            if (!Commands.ContainsKey(_input[0]))
            {
                Debug.LogWarning("\"" + _input[0] + "\" - Unknown command.");
            }

            // Run the command
            else if (_input.Length == 1)
            {
                Commands[_input[0]].RunCommand(null);
            } 
            else
            {
                Commands[_input[0]].RunCommand(_input.Skip(1).ToArray());
            }
        }
    }
}
