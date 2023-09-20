using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextbot : MonoBehaviour
{
    //Loads nextbot based upon the player-chosen button

    [SerializeField] private GameObject skylar;
    [SerializeField] private GameObject chris;
    [SerializeField] private GameObject wyatt;
    [SerializeField] private GameObject tianhao;
    [SerializeField] private GameObject roman;

    private void Update()
    {
        switch (NextBotChoice.nextbotSelection)
        {
            case "Chris":
                chris.SetActive(true);
                break;
            case "Skylar":
                skylar.SetActive(true);
                break;
            case "Wyatt":
                wyatt.SetActive(true);
                break;
            case "Tianhao":
                tianhao.SetActive(true);
                break;
            case "Roman":
                roman.SetActive(true);
                break;
        }
    }
}
