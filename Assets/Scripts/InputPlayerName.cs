using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputPlayerName : MonoBehaviour
{
    public void Start20WordsGame()
    {
        PlayerPrefs.SetString("GameMode", "Arcade");
        SceneManager.LoadScene(1);
    }

    public void StartNonStopGame()
    {
        PlayerPrefs.SetString("GameMode", "Training");
        SceneManager.LoadScene(1);
    }
}
