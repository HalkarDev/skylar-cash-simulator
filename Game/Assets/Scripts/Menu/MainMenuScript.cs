using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private float loadSensitivity;
    public static float ClickOffTime;
    [SerializeField] private AudioSource menuMusic;
    public static string location;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider volumeSlider;
    int loadDay;
    int loadWeek;

    //each of the methods correspond with buttons in the main menu
    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("VolumeSliderValue");
        if (location == "nextbot")
        {
            menuMusic.time = NextBotChoice.clickOffTime;
        }
        else if (location == "sensitivity")
        {
            menuMusic.time = Settings.clickOffTime;
        }
        loadSensitivity = PlayerPrefs.GetFloat("Sensitivity");
        Settings.Sensitivity = loadSensitivity;
        PlayerMovement.Sens = Settings.Sensitivity;
    }
    public void NextBotMode()
    {
        ClickOffTime = menuMusic.time;
        SceneManager.LoadScene(4);
    }
    public void LoadGame()
    {
        //loads day and week
        loadDay = PlayerPrefs.GetInt("Day");
        loadWeek = PlayerPrefs.GetInt("Week");
        DayWeek.Day = loadDay;
        DayWeek.week = loadWeek;
        SceneManager.LoadScene(1);
    }
    public void NewGame()
    {
        //resets day and week
        DayWeek.Day = 1;
        DayWeek.week = 1;
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void SettingsLoad()
    {
        ClickOffTime = menuMusic.time;
        SceneManager.LoadScene(6);
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("VolumeSliderValue", volumeSlider.value);
    }
}
