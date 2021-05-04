using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Lives : MonoBehaviour
{
    public Dropdown dropDown;

    public static int lives = 9;
    public void LivesMenu()
    {
        switch (dropDown.value)
        {
            case 1:
                lives = 1;
                break;
            case 2:
                lives = 2;
                break;
            case 3:
                lives = 3;
                break;
            case 4:
                lives = 4;
                break;
            case 5:
                lives = 5;
                break;
            case 6:
                lives = 6;
                break;
            case 7:
                lives = 7;
                break;
            case 8:
                lives = 8;
                break;
            case 9:
                lives = 9;
                break;
            default:
                lives = 3;
                break;
        }
    }
}
