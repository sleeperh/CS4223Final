using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Name : MonoBehaviour
{
    public InputField inputField;

    public static string currentName;
    public void SaveName()
    {
        currentName = inputField.text;
    }
}
