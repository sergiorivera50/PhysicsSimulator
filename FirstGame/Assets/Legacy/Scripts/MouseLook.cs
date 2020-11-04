using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	public float defaultMouseSensitivity = 100f;
	private float mouseSensitivity;

	[SerializeField] private Transform playerBody;

	private float yRotation = 0f;

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		mouseSensitivity = defaultMouseSensitivity;
	}
	
	// Update is called once per frame
	void Update () {
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
		
		yRotation -= mouseY;
		yRotation = Mathf.Clamp(yRotation, -90f, 90f);

		transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
		playerBody.Rotate(Vector3.up * mouseX);
		// Debug.Log(mouseSensitivity);
	}

	public void adjustSensitivity(float newSensitivity)
	{
		mouseSensitivity = defaultMouseSensitivity + 100 * newSensitivity;
	}
}
