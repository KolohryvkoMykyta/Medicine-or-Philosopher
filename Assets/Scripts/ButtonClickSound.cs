using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    public AudioSource ButtonClick;

    public void PlayButtonClick()
    {
        ButtonClick.Play();
    }
}
