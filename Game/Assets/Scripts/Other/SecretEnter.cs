using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretEnter : MonoBehaviour
{
    //script for when the player walks through the trigger. this starts the music
    [SerializeField] AudioSource secretVideoMusic;
    public static bool VideoPlaying;
    public static float SecretMusicTime;

    void OnTriggerEnter(Collider other)
    {
        if (!VideoPlaying)
        {
            VideoPlaying = true;
            secretVideoMusic.Play();
            secretVideoMusic.time = SecretMusicTime;
        }
    }
}
