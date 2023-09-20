using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    //Shows a special death message
    private int randomMessage;
    private Text text;
    [SerializeField] private GameObject DeathMessage;
    private void Start()
    {
        text = DeathMessage.GetComponent<Text>();
        randomMessage = Random.Range(1, 21);
        switch (randomMessage)
        {
            case 1:
                text.text = "You can do this!";
                break;
            case 2:
                text.text = "Don't give up!";
                break;
            case 3:
                text.text = "I spent way too much time on this game for you to quit now!";
                break;
            case 4:
                text.text = "I love the way you move! -Skylar Cash";
                break;
            case 5:
                text.text = "Wyatt's house 3.0 on Friday! -Skylar Cash";
                break;
            case 6:
                text.text = "The stars twinkle as you fall to the ground, your last dying breath being a moment written forever in the history books.";
                break;
            case 7:
                text.text = "So, what do ya' need?";
                break;
            case 8:
                text.text = "Did you just hear that crack? -Skylar Cash";
                break;
            case 9:
                text.text = "I'm running out of ideas for what to write for these death messages...";
                break;
            case 10:
                text.text = "Should I write some more inappropriate things here?";
                break;
            case 11:
                text.text = "You got this!";
                break;
            case 12:
                text.text = "You will overcome this challenge!";
                break;
            case 13:
                text.text = "Is it really that hard? Maybe you should go do something more productive...";
                break;
            case 14:
                text.text = "You got this one in the bag!";
                break;
            case 15:
                text.text = "[Redacted] -Freddy Zuckerman";
                break;
            case 16:
                text.text = "*screeching intensifies* -Chris Oswald";
                break;
            case 17:
                text.text = "Roman, what score did you get on the test? -Tianhao Zheng";
                break;
            case 18:
                text.text = "This game ain't that hard.";
                break;
            case 19:
                text.text = "You're garbage.";
                break;
            default:
                text.text = "Deepwoken. Deepwoken. Deepwoken. Deepwoken. Deepwoken. -Dominic Harrass!";
                break;


        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine("Fade");
        }
    }
    IEnumerator Fade()
    {
        GetComponent<Animator>().Play("Dying");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}
