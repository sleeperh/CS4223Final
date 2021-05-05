
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    public Text scoreTextBox;
    public static int cleared;
    private int currentScore = Points.currentPoints;
    private string currentName = Name.currentName;
    private string path = Directory.GetCurrentDirectory() + "/Assets/ScoreData/ScoreData.txt";
    private void Awake()
    {
        HighScoreEntry highScoreEntry = new HighScoreEntry { score = currentScore, name = currentName }; // save current name and score to class object
        string jsonString = File.ReadAllText(path); // read text file into json string
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString); // pass json string into HighScore class containing a list of scores
        if(highScores == null)  // if list is empty
        {
            highScores = new HighScores()
            {
                highScoreEntryList = new List<HighScoreEntry>() // instantiate list in HighScore class
            };
        }
        
        highScores.highScoreEntryList.Add(highScoreEntry); // add current stats to list

        // sort list of HighScoreEntry objects based on score
        for (int i = 0; i < highScores.highScoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highScores.highScoreEntryList.Count; j++)
            {
                if (highScores.highScoreEntryList[j].score > highScores.highScoreEntryList[i].score)
                {
                    // Swap
                    HighScoreEntry tmp = highScores.highScoreEntryList[i];
                    highScores.highScoreEntryList[i] = highScores.highScoreEntryList[j];
                    highScores.highScoreEntryList[j] = tmp;
                }
            }
        }
        string json = JsonUtility.ToJson(highScores); // save sorted list to json string
        File.WriteAllText(path, json); // save json string to text file
        DisplayHighScores(highScores); // display high score entries
    }

    private void DisplayHighScores(HighScores highScores)
    {
        string scores = "";

        for (int i = 0; i < highScores.highScoreEntryList.Count; i++)
        {
            if (i == 10)
                break; // only display 10 of the scores
            int rank = i + 1;
            string name = highScores.highScoreEntryList[i].name;
            string score = highScores.highScoreEntryList[i].score.ToString();
            int rankWidth = 29; 
            if (i == 9)
            {
                rankWidth = 28; 
            }
            int scoreWidth = 31 - (score.Length + name.Length);
            
            scores += "     " + rank.ToString().PadRight(rankWidth) + score.PadRight(scoreWidth) + name + "\n";
        }
        scoreTextBox.text = scores;
        
    }
    public void ClearScores()
    {
        Points.currentPoints = 0;
        Name.currentName = "";
        string cleared = "";
        File.WriteAllText(path, cleared);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }

    private class HighScores
    {
        public List<HighScoreEntry> highScoreEntryList;
    }

    [System.Serializable]
    public class HighScoreEntry
    {
        public int score;
        public string name;
    }
}
