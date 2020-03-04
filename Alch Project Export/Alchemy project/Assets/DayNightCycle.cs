using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{

    private float daycycle;
    private const float Seconds_Per_Day = 360f;
    private Text timeText;
    

    // Start is called before the first frame update
    void Start()
    {
        timeText = GameObject.Find("timeText").GetComponent<Text>(); // text search
    }

    // Update is called once per frame
    void Update()
    {
        daycycle += Time.deltaTime / Seconds_Per_Day; //in game time vs real time 

        float daycycleNormalised = daycycle % 1f;
        float HoursPerDay = 24f; // 24 hours

        string hoursString = Mathf.Floor(daycycleNormalised * 24f).ToString("00"); // Hours calculation out of 24 hours

        float minutesPerHour = 60f; // 60 mins per hour
        string minutesString = Mathf.Floor(((daycycleNormalised * HoursPerDay) % 1f) * minutesPerHour).ToString("00");  //minutes calculation (not, rounded up)

        timeText.text = hoursString + ":" + minutesString;
    }
}
