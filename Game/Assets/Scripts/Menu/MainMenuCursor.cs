using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCursor : MonoBehaviour
{
    //Makes cursor appear when in main menu
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
