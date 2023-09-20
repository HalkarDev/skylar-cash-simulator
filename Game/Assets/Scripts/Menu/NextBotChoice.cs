using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextBotChoice : MonoBehaviour
{
    public static string nextbotSelection;
    public AudioSource menuMusic;
    public static float clickOffTime;
    private void Start()
    {
        menuMusic.time = MainMenuScript.ClickOffTime;
        menuMusic.Play();
    }
    //each of the following methods correspond with the buttons in the nextbot menu
    public void Skylar()
    {
        nextbotSelection = "Skylar";
        SceneManager.LoadScene(3);
    }
    public void Chris()
    {
        nextbotSelection = "Chris";
        SceneManager.LoadScene(3);
    }
    public void Wyatt()
    {
        nextbotSelection = "Wyatt";
        SceneManager.LoadScene(3);
    }
    public void Tianhao()
    {
        nextbotSelection = "Tianhao";
        SceneManager.LoadScene(3);
    }
    public void Roman()
    {
        nextbotSelection = "Roman";
        SceneManager.LoadScene(3);
    }
    public void Back()
    {
        MainMenuScript.location = "nextbot";
        clickOffTime = menuMusic.time;
        SceneManager.LoadScene(0);
    }

}
