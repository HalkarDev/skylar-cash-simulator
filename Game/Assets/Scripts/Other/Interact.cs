using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    //Controls opening door in house
    [SerializeField] private GameObject E;
    [SerializeField] private GameObject theText;
    [SerializeField] private AudioSource openDoor;
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject hinge;
    [SerializeField] private GameObject doorView;
    [SerializeField] private GameObject player;
    public static bool OpeningDoor;
    private bool interactingDoor;
    private void OnTriggerStay(Collider other)
    {
        //shows small 'e' in the top corner when getting close to door
        if (!interactingDoor)
        {
            E.SetActive(true);
            theText.GetComponent<Animator>().Play("FadingInText");
            E.GetComponent<Animator>().Play("Fading");
        }
        if (Input.GetKey(KeyCode.E) && !OpeningDoor)
        {
            StartCoroutine(OpenDoor());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeOut()
    {
        //fades 'E' when getting away from door
        interactingDoor = true;
        theText.GetComponent<Animator>().Play("FadingOutText");
        E.GetComponent<Animator>().Play("Fading out");
        yield return new WaitForSeconds(.5f);
        E.SetActive(false);
        interactingDoor = false;
    }
    IEnumerator OpenDoor()
    {
        OpeningDoor = true;
        player.GetComponent<MeshRenderer>().enabled = false;
        Camera.main.gameObject.SetActive(false);
        doorView.SetActive(true);
        hinge.GetComponent<Animator>().Play("Open");
        background.GetComponent<Animator>().Play("Dying");
        openDoor.Play();
        yield return new WaitForSeconds(1.5f);
        OpeningDoor = false;
        SceneManager.LoadScene(5);
    }
}
