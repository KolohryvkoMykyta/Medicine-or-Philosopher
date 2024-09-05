using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class HighScoreTable : MonoBehaviour
{
    public TextMeshProUGUI[] highScoreName;
    public TextMeshProUGUI[] hightScoreCorrectAnswers;
    public TextMeshProUGUI[] hightScorePercentage;
    public List<HighScoreEntry> highScores = new List<HighScoreEntry>();
    public int maxEntries = 10;

    private void Start()
    {
        LoadHighScores();
        DisplayHighScores();
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

    private void DisplayHighScores()
    {
        for (int i = 0; i < highScores.Count; i++)
        {
            if (i < highScores.Count)
            {
                highScoreName[i].text = $"{i + 1} {highScores[i].name}:";
                hightScoreCorrectAnswers[i].text = $"{highScores[i].score}/20";
                hightScorePercentage[i].text = $"{highScores[i].percentageScore}%";
            }
            else
            {
                highScoreName[i].text = "";
            }
        }
    }
    public void ClearHighScores()
    {
        for (int i = 0; i < highScores.Count; i++)
        {
            string nameKey = "Name_" + i;
            string scoreKey = "Score_" + i;
            string percentageScoreKey = "PercentageScore_" + i;

            PlayerPrefs.SetString(nameKey, "Anonimus");
            PlayerPrefs.SetInt(scoreKey, 0);
            PlayerPrefs.SetInt(percentageScoreKey, 0);
        }

        PlayerPrefs.Save();

        LoadHighScores();
        DisplayHighScores();
    }
}
