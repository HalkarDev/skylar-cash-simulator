using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    //Controls position and rotation of camera
    [SerializeField] private Transform cameraPosition;
    void Update()
    {
        transform.position = cameraPosition.position;
        transform.rotation = Quaternion.Euler(PlayerMovement.RotationX, PlayerMovement.RotationY, 0);
        
    }
}
