using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    public Text timerTxt;
    public static float timeRemaining;
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = TimeSlider.timeValue;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timerTxt.text = timeRemaining.ToString("00.000");
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }    
        else
        {
            timeRemaining = 0; // stop counting when 0 is reached
        }
    }
}
