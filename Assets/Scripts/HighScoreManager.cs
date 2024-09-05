using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HighScoreEntry
{
    public string name;
    public int score;
    public int percentageScore;
    public HighScoreEntry()
    {
        name = "Anonymous";
        score = 0;
        percentageScore = 0;
    }
}

public class HighScoreManager : MonoBehaviour
{
    public List<HighScoreEntry> highScores = new List<HighScoreEntry>();
    public int maxEntries = 10;

    private void Start()
    {
        LoadHighScores();
    }

    private void LoadHighScores()
    {
        highScores.Clear();

        for (int i = 0; i < maxEntries; i++)
        {
            string nameKey = "Name_" + i;
            string scoreKey = "Score_" + i;
            string percentageScoreKey = "PercentageScore_" + i;

            if (PlayerPrefs.HasKey(nameKey) && PlayerPrefs.HasKey(scoreKey) && PlayerPrefs.HasKey(percentageScoreKey))
            {
                string name = PlayerPrefs.GetString(nameKey);
                int score = PlayerPrefs.GetInt(scoreKey);
                int percentageScore = PlayerPrefs.GetInt(percentageScoreKey);

                highScores.Add(new HighScoreEntry { name = name, score = score, percentageScore = percentageScore });
            }
            else
            {
                highScores.Add(new HighScoreEntry());
            }
        }

        highScores.Sort((x, y) => y.score.CompareTo(x.score));
    }

    public void AddHighScore(string playerName, int score, int percentageScore)
    {
        highScores.Add(new HighScoreEntry { name = playerName, score = score, percentageScore = percentageScore });

        highScores.Sort((x, y) => y.score.CompareTo(x.score));

        if (highScores.Count > maxEntries)
        {
            highScores.RemoveRange(maxEntries, highScores.Count - maxEntries);
        }

        SaveHighScores();
    }

    private void SaveHighScores()
    {
        for (int i = 0; i < highScores.Count; i++)
        {
            string nameKey = "Name_" + i;
            string scoreKey = "Score_" + i;
            string percentageScoreKey = "PercentageScore_" + i;

            PlayerPrefs.SetString(nameKey, highScores[i].name);
            PlayerPrefs.SetInt(scoreKey, highScores[i].score);
            PlayerPrefs.SetInt(percentageScoreKey, highScores[i].percentageScore);
        }

        PlayerPrefs.Save();
    }
}
