using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorView : MonoBehaviour
{
    //Sets audio listener off so there are not more than two audio listeners when opening door in bedroom because of camera change
    private void OnEnable()
    {
        this.gameObject.GetComponent<AudioListener>().enabled = true;
    }
}
