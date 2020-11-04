using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public Transform player;

    private void Update() {
        transform.position = player.transform.position;
    }
}