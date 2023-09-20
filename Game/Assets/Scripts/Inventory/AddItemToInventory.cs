using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemToInventory : MonoBehaviour
{
    [SerializeField] private GameObject importance;

    private void OnTriggerEnter(Collider other)
    {
        OpenInventory.AddItem(importance);
    }
}
