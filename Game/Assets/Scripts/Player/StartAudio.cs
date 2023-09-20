using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudio : MonoBehaviour
{
    //Randomizes the start time of the footstep audio

    private AudioSource footsteps;
    int audioBeginTime;

    private void Awake()
    {
        footsteps = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        audioBeginTime = Random.Range(0, 10);
        footsteps.time = audioBeginTime;
    }
}
