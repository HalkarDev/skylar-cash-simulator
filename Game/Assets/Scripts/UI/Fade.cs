using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    //Controls what happens when you die
    [SerializeField] private GameObject empty;
    [SerializeField] private GameObject player;
    private void Awake()
    {
        Health.Health1 = 100;
    }
    void Update()
    {
        if (Health.Health1 <= 0)
        {
            StartCoroutine("Death");
        }
    }
    IEnumerator Death()
    {
        empty.SetActive(false);
        player.SetActive(false);
        GetComponent<Animator>().Play("Dying");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }
}

