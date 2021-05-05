using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NameDisplay : MonoBehaviour
{
    public Text nameText;
    private string currentName;
    // Start is called before the first frame update
    void Start()
    {
        currentName = Name.currentName;
    }

    // Update is called once per frame
    void Update()
    {
        nameText.text = "Currently playing: " + currentName;
    }
}
