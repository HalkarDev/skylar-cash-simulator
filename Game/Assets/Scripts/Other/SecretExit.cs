using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretExit : MonoBehaviour
{
    //script for when the player walks through the trigger. this stops the music
    [SerializeField] AudioSource secretVideoMusic;

    void OnTriggerEnter(Collider other)
    {
        if (SecretEnter.VideoPlaying)
        {
            SecretEnter.SecretMusicTime = secretVideoMusic.time;
            secretVideoMusic.Stop();
            SecretEnter.VideoPlaying = false;
        }
    }
}
