using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private InventorySystem inventory;
    public GameObject itemIcon;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter!");
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (!inventory.isFull[i])
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemIcon, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    Debug.Log("Destroy!");
                    return;
                }
            }
        }
        Debug.Log("OnTriggerExit!");
    }
}
