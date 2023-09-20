using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Text;
using UnityEditor;

public class DayWeek : MonoBehaviour
{


    TextMeshProUGUI Text;
    public static string dayS;
    public static int week = 1;
    public static int Day = 1;

    private void Start()
    {
        Text = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        //Assigns a day depending on day integer
        switch (Day)
        {
            case 1:
                dayS = "Monday";
                break;
            case 2:
                dayS = "Tuesday";
                break;
            case 3:
                dayS = "Wednesday";
                break;
            case 4:
                dayS = "Thursday";
                break;
            case 5:
                dayS = "Friday";
                break;
            case 6:
                dayS = "Saturday";
                break;
            case 7:
                dayS = "Sunday";
                break;

        }
        Text.text = $"{dayS}, Week {week}";
    }


    //Progresses through the days when called
    public static void PassDay()
    {
        Day++;
        if (Day == 8)
        {
            if (week == 10)
            {
                week = 10;
                Day = 7;
            }
            else
            {
                week++;
                Day = 1;
            }

        }
    }
}
