using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        nameInputField.text = PlayerPrefs.GetString("playerName", "Anonymus");
        volumeSlider.value = PlayerPrefs.GetFloat("volumeSlider", 1f);
        AudioListener.volume = volumeSlider.value;
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    public void SetPlayerName(string playerName)
    {
        PlayerPrefs.SetString("playerName", playerName);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("volumeSlider", volume);
    }
}
