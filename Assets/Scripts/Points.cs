using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Points : MonoBehaviour
{
    public Text pointsText;
    public static int currentPoints;
    // Start is called before the first frame update
    void Start()
    {
        currentPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = currentPoints.ToString();
    }

    public void IncreasePoints()
    {
        currentPoints += 1;
    }
    public void DecreasePoints()
    {
        currentPoints -= 1;
    }
}
