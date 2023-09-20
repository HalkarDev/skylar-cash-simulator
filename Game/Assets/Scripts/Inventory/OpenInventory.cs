using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    private bool inventoryOpen;
    [SerializeField] private GameObject inventory;

    //inventory represented by array
    public static GameObject[] inventoryArray = new GameObject[8];

    //called when item is to be added to inventory
    public static void AddItem(GameObject item)
    {
        for (int i = 0; i < inventoryArray.Length; i++)
        {
            if (inventoryArray[i] != null)
            {
                inventoryArray[i] = item;
                break;
            }
        }
    }


    private void Update()
    {
        //opens inventory
        if (Input.GetKeyUp(KeyCode.Q) && !inventoryOpen)
        {
            inventoryOpen = true;
            inventory.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Input.GetKeyUp(KeyCode.Q) && inventoryOpen)
        {
            inventoryOpen = false;
            inventory.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
