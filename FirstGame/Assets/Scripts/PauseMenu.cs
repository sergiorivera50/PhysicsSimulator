using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
	[SerializeField] private GameObject pauseMenuUI;
	[SerializeField] private bool isPaused;

	private float pausedTimeScale;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			isPaused = !isPaused;
			
			if (isPaused)
			{
				pausedTimeScale = Time.timeScale;
				Time.timeScale = 0;
				Cursor.lockState = CursorLockMode.Confined;
				Cursor.visible = true;
				ActivateMenu();
			}
			else
			{
				Time.timeScale = pausedTimeScale;
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				DeactivateMenu();
			}
		}
	}

	void ActivateMenu()
	{
		pauseMenuUI.SetActive(true);
	}

	void DeactivateMenu()
	{
		pauseMenuUI.SetActive(false);
	}
}
