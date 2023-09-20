using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    //Has health of player as private variable and then property
    [SerializeField] private GameObject healthValue;
    private static float health = 100;
    public static float Health1
    {
        set
        {
            if (value < 0)
            {
                health = 0;
            }
            else
            {
                health = value;
            }
        }
        get
        {
            return health;
        }
    }
    private void Update()
    {
        //Controls size of health panel in relation to the current health value
        transform.localScale = new Vector3(health / 312.5f, 0.16f, 1);
        healthValue.GetComponent<TextMeshProUGUI>().text = $"Health: {Health1:f1}";
    }
}
