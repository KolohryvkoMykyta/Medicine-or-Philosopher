using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public GameManager GameManagerScript;
    public AudioManager AudioManagerScript;
    public GameObject TimerObject;
    public TextMeshProUGUI Countdoun;
    public GameObject LeftArrow;
    public GameObject RightArrow;

    private Coroutine arrowSwitch;
    private Coroutine countdownCoroutine;
    private float timer = 9f;
    private bool isArrowActive = false;
    public void StartTimer()
    {
        if (countdownCoroutine == null)
        {
            timer = 9f;
            countdownCoroutine = StartCoroutine(Countdown());
            TimerObject.SetActive(true);
            StartArrowSwitch();
        }
    }
    public void StopTimer()
    {
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
            countdownCoroutine = null;
            TimerObject.SetActive(false);
            StopArrowSwitch();
        }
    }
    public bool IsTimerRunning()
    {
        return countdownCoroutine != null;
    }

    private void StartArrowSwitch()
    {
        if (arrowSwitch == null)
        {
            arrowSwitch = StartCoroutine(ArrowSwitch());
        }
    }

    public void StopArrowSwitch() 
    {
        if (arrowSwitch != null)
        {
            StopCoroutine(arrowSwitch);
            arrowSwitch = null;
            LeftArrow.SetActive(false);
            RightArrow.SetActive(false);
        }
    }

    private IEnumerator Countdown()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);
            timer -= 1f;

            if (timer < 4f && timer > 0)
            {
                AudioManagerScript.PlayTimer();
            }

            if (timer <= 0)
            {
                AudioManagerScript.PlayWrongSound();
                GameManagerScript.ShowDescription();
                GameManagerScript.resultTextTimeUp.gameObject.SetActive(true);
                
                StopTimer();
                GameManagerScript.SetButtonsInteractable(false, false, true);
            }
        }
    }

    private IEnumerator ArrowSwitch()
    {
        while (true) 
        {
            yield return new WaitForSeconds(0.25f);
            LeftArrow.SetActive(isArrowActive);
            RightArrow.SetActive(!isArrowActive);
            isArrowActive = !isArrowActive;
        }
    }

    private void Start()
    {
        GameManagerScript = GetComponent<GameManager>();
        AudioManagerScript = GameObject.FindObjectOfType<AudioManager>();
        Countdoun.text = timer.ToString();
    }

    private void Update()
    {
        Countdoun.text = timer.ToString();
    }
}
