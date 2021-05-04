using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlider : MonoBehaviour
{
    public static float timeValue = 60f;

    public void SetTimeValue(float value)
    {
        timeValue = value;
    }
}
