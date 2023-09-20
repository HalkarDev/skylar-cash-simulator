using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ReturnHome : MonoBehaviour
{
    //controls leaving school (adapted version of the interact script)
    [SerializeField] private GameObject E;
    [SerializeField] private GameObject theText;
    [SerializeField] private GameObject background;
    bool interactingSchool;
    bool leavingSchool;
    [SerializeField] GameObject player;
    [SerializeField] private GameObject returnHomeText;
    private void OnTriggerStay(Collider other)
    {
        if (!interactingSchool)
        {
            E.SetActive(true);
            returnHomeText.SetActive(true);
            E.GetComponent<Animator>().Play("Fading");
            theText.GetComponent<Animator>().Play("FadingInText");
            returnHomeText.GetComponent<Animator>().Play("Fading");
        }
        if (Input.GetKey(KeyCode.E) && !leavingSchool)
        {
            StartCoroutine(LeavingSchool());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeOut()
    {
        interactingSchool = true;
        theText.GetComponent<Animator>().Play("FadingOutText");
        E.GetComponent<Animator>().Play("Fading out");
        returnHomeText.GetComponent<Animator>().Play("Fading out");
        yield return new WaitForSeconds(.5f);
        E.SetActive(false);
        returnHomeText.SetActive(false);
        interactingSchool = false;
    }
    IEnumerator LeavingSchool()
    {
        leavingSchool = true;
        background.GetComponent<Animator>().Play("Dying");
        yield return new WaitForSeconds(1);
        leavingSchool = false;
        DayWeek.PassDay();
        SceneManager.LoadScene(1);
    }
}
