using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGunController : Gun
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Camera mainCamera = Camera.main;
        RaycastHit hit;
        int playerLayerMask = 1 << 11;
        playerLayerMask = ~playerLayerMask;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, maxRange, playerLayerMask))
        {
            Debug.Log("Hit: " + hit.transform);
            if (hit.transform.tag=="interact")
            {
                Destroy(hit.transform);
            }
        }
    }
}