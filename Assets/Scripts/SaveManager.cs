using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    private Save CreateSaveGameObject()
    {
        Save save = new Save();
        save.currentPoints = Points.currentPoints;
        save.livesRemaining = Lives.lives;
        save.timeRemaining = TimerDisplay.timeRemaining;
        return save;
    }
    public void SaveGame()
    {
        Save save = CreateSaveGameObject();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();
        Debug.Log("Game Saved!");
    }

    public void SaveAsJSON()
    {
        Save save = CreateSaveGameObject();
        string json = JsonUtility.ToJson(save);
        Debug.Log("Saving as JSON: " + json);
    }
    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save")) 
        {
            BinaryFormatter bf = new BinaryFormatter(); 
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();
            // load the saved information into the game
            Points.currentPoints = save.currentPoints;
            Lives.lives = save.livesRemaining;
            TimerDisplay.timeRemaining = save.timeRemaining;
            Debug.Log("Game Loaded! Score: " + save.currentPoints);
        }
        else
            Debug.Log("No game saved!");
    }
    public void NewGame()
    {
        SceneManager.LoadScene("1Intro");
    }
}
