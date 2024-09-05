using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource Timer;
    public AudioSource WrongSound;
    public AudioSource CorrectSound;

    public void PlayTimer()
    {
        Timer.Play();
    }
    public void PlayWrongSound()
    {
        WrongSound.Play();
    }
    public void PlayCorrectSound()
    {
        CorrectSound.Play();
    }
}
