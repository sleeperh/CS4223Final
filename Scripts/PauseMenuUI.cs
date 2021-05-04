using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject continueBtn;
    public GameObject newGameBtn;
    public GameObject saveGameBtn;
    public GameObject saveJSONBtn;
    public GameObject loadBtn;
    public GameObject musicTgle;
    public AudioSource musicFile;
    public Toggle toggle;

    public static bool pauseBool = false;

    private void Awake()
    {
        PauseUI(false); // initially false
        if (!PlayerPrefs.HasKey("Music"))
        {
            PlayerPrefs.SetInt("Music", 1);
            toggle.isOn = true;
            musicFile.enabled = true;
            PlayerPrefs.Save();
        }
        else
        {
            if (PlayerPrefs.GetInt("Music") == 0)
            {
                musicFile.enabled = false;
                toggle.isOn = false;
            }
            else
            {
                musicFile.enabled = true;
                toggle.isOn = true;
            }
        }
    }

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!pauseBool)
            {
                PauseUI(true);
                pauseBool = true;
            }    
            else
            {
                PauseUI(false);
                pauseBool = false;
            }
        }
        PlayerPrefs.GetInt("Music");
    }

    private void PauseUI(bool activeBool)
    {
        pausePanel.SetActive(activeBool);

        continueBtn.SetActive(activeBool);
        newGameBtn.SetActive(activeBool);
        saveGameBtn.SetActive(activeBool);
        saveJSONBtn.SetActive(activeBool);
        loadBtn.SetActive(activeBool);
        musicTgle.SetActive(activeBool);
        if (activeBool)
        {
            Time.timeScale = 0;
        }
        else
            Time.timeScale = 1;
    }    

    public void ContinueGame()
    {
        PauseUI(false);
    }

    public void MusicToggler(bool active)
    {
        if (active)
        {
            musicFile.Play();
        }
        else if (!active)
        {
            musicFile.Stop();
        }
    }
}
