using Assets.DeveloperConsole.Commands;
using TMPro;
using UnityEngine;

namespace Assets.DeveloperConsole
{
    public class DeveloperConsoleBehaviour : MonoBehaviour
    {
        [SerializeField] private string prefix = string.Empty;
        [SerializeField] private ConsoleCommand[] commands = new ConsoleCommand[0];

        [Header("UI")]
        [SerializeField] private GameObject UICanvas = null;
        [SerializeField] private TMP_InputField inputField = null;

        private float pausedTimeScale;
        private static DeveloperConsoleBehaviour instance;
        
        private DeveloperConsole developerConsole;
        private DeveloperConsole DeveloperConsole
        {
            get
            {
                if (developerConsole != null) return developerConsole;
                return developerConsole = new DeveloperConsole(prefix, commands);
            }
        }

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;

            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (UICanvas.activeSelf)
                {
                    Time.timeScale = pausedTimeScale;
                    UICanvas.SetActive(false);
                } 
                else
                {
                    pausedTimeScale = Time.timeScale;
                    UICanvas.SetActive(true);
                    inputField.ActivateInputField(); // it will activate input field without having to click
                    Time.timeScale = 0;
                }
            }
        }

        public void ProcessCommand(string inputValue)
        {
            DeveloperConsole.ProcessCommand(inputValue);
            inputField.text = string.Empty;
        }
    }
}
