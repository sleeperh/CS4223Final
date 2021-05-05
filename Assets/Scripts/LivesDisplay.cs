using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LivesDisplay : MonoBehaviour
{
    public Text livesText;
    
 

    // Update is called once per frame
    void Update()
    {
        livesText.text = Lives.lives.ToString();
    }
    public void DecreaseLives()
    {
        Lives.lives -= 1;
    }
    public void IncreaseLives()
    {
        Lives.lives += 1;
    }
}
