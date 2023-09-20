using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    //Controls the setting of sensitivity in the mouse sensitivity setting screen
    [SerializeField] private Slider sensitivitySlider;
    [SerializeField] private TextMeshProUGUI text;
    private static float sensitivity;
    private float sliderSens;


    public static float Sensitivity
    {
        get
        {
            return sensitivity;
        }
        set
        {
            if (value == 0)
            {
                sensitivity = 150;
            }
            else
            {
                sensitivity = value;
            }
        }
    }

    public AudioSource mainMenuMusic;
    public static float clickOffTime;
    private void Awake()
    {
        sliderSens = PlayerPrefs.GetFloat("SliderSens");
        sensitivitySlider.value = sliderSens;
        mainMenuMusic.time = MainMenuScript.ClickOffTime;
        sensitivity = 150;
    }
    private void Update()
    {
        PlayerPrefs.SetFloat("Sensitivity", sensitivity);
        PlayerMovement.Sens = Sensitivity;
        Sensitivity = Convert.ToSingle(sensitivitySlider.value) * 300;
        string myString = $"{Sensitivity:f0}";
        text.text = myString;
        if (Sensitivity == 150)
        {
            sensitivitySlider.value = .5f;
        }
    }
    public void Back()
    {
        MainMenuScript.location = "sensitivity";
        clickOffTime = mainMenuMusic.time;
        //Saving position of slider
        PlayerPrefs.SetFloat("SliderSens", sensitivitySlider.value);
        SceneManager.LoadScene(0);
    }
    public void FullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }
}
