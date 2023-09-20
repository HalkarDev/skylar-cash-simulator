using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsTurnOff : MonoBehaviour
{
    //Turns off footsteps sound while opening door in bedroom
    private void Update()
    {
        if (Interact.OpeningDoor)
        {
            this.gameObject.SetActive(false);
        }
    }
}
