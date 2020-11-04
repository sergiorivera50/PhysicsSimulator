using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphyController : MonoBehaviour
{
	[SerializeField] private GameObject graphyUI;
	[SerializeField] private bool isShown;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.F3))
		{
			isShown = !isShown;
		}

		if (isShown)
		{
			ActivateGraphy();
		}
		else
		{
			DeactivateGraphy();
		}
	}

	void ActivateGraphy()
	{
		graphyUI.SetActive(true);
	}

	void DeactivateGraphy()
	{
		graphyUI.SetActive(false);
	}
}
