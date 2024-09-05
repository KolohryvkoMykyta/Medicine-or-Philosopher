using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Main;
    public GameObject FinishGame;
    public TextMeshProUGUI wordText;
    public TextMeshProUGUI resultTextCorrect;
    public TextMeshProUGUI resultTextWrong;
    public TextMeshProUGUI resultTextTimeUp;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI CorrectAnswersCount;
    public TextMeshProUGUI finalResults;
    public TextMeshProUGUI finalResultsPersetage;
    public Button nextButton;
    public Button philosopherButton;
    public Button medicineButton;
    public Timer timerScript;
    public AudioManager AudioManagerScript;
    public HighScoreManager HighScoreManagerScript;

    private List<WordData> wordsData = new List<WordData>();
    private int currentIndex = 0;
    private int correctAnswers = 0;
    private int wordsCounter = 0;
    private int maxWords = 20;
    private string gameMode;
    private string playerName;

    void Start()
    {
        timerScript = GetComponent<Timer>();
        HighScoreManagerScript = GetComponent<HighScoreManager>();
        AudioManagerScript = GameObject.FindObjectOfType<AudioManager>();
        playerName = PlayerPrefs.GetString("playerName", "Anonimus");
        resultTextCorrect.text = string.Empty;
        LoadWordsFromFile("words");
        ShuffleWords();
        gameMode = PlayerPrefs.GetString("GameMode", "Training");

        if (gameMode == "Arcade")
            StartArcadeGame();
        else
            StartTrainingGame();
    }
    private void StartTrainingGame()
    {
        ShowNextWord();
        nextButton.onClick.AddListener(NextWordButton);
        CorrectAnswersCount.text = $"{correctAnswers}/{wordsCounter}";
    }

    private void StartArcadeGame()
    {
        ShowNextWordWithTimer();
        nextButton.onClick.AddListener(NextWordButtonTimer);
        CorrectAnswersCount.text = $"{correctAnswers}/{wordsCounter}";
    }

    private void ShowResults()
    {
        finalResults.text = $"{correctAnswers}/{wordsCounter}";
        finalResultsPersetage.text = $"{((float)correctAnswers / maxWords) * 100}%";

        HighScoreManagerScript.AddHighScore(playerName, correctAnswers, (int)(((float)correctAnswers / maxWords) * 100));

        Main.SetActive(false);
        FinishGame.SetActive(true);

        if (timerScript.IsTimerRunning())
            timerScript.StopTimer();
    }

    void LoadWordsFromFile(string filename)
    {
        string language = PlayerPrefs.GetString("Language", "en-US");
        TextAsset jsonFile = Resources.Load<TextAsset>($"{filename}-{language}");

        if (jsonFile != null)
        {
            string dataAsJson = jsonFile.text;
            WordList wordList = JsonUtility.FromJson<WordList>(dataAsJson);
            wordsData.AddRange(wordList.words);
        }
        else
        {
            Debug.LogError("Cannot load word file!");
        }
    }

    void ShuffleWords()
    {
        wordsData = wordsData.OrderBy(x => Random.value).ToList();
    }

    void ShowNextWord()
    {
        wordsCounter++;

        resultTextCorrect.gameObject.SetActive(false);
        resultTextWrong.gameObject.SetActive(false);
        resultTextTimeUp.gameObject.SetActive(false);

        currentIndex = (currentIndex + 1) % wordsData.Count;
        CorrectAnswersCount.text = $"{correctAnswers}/{wordsCounter}";

        wordText.text = wordsData[currentIndex].word;
        descriptionText.text = string.Empty;

        philosopherButton.interactable = true;
        medicineButton.interactable = true;
        nextButton.interactable = false;
    }

    void ShowNextWordWithTimer()
    {
        timerScript.StartTimer();

        if (wordsCounter >= maxWords)
            ShowResults();

        ShowNextWord();
    }

    public void SetButtonsInteractable(bool philosopherButtonInteractable, bool medicineButtonInteractable, bool nextButtonInteractable)
    {
        philosopherButton.interactable = philosopherButtonInteractable;
        medicineButton.interactable = medicineButtonInteractable;
        nextButton.interactable = nextButtonInteractable;
    }

    public void ChoosePhilosopher()
    {
        if(timerScript.IsTimerRunning())
            timerScript.StopTimer();
        ShowDescription();
        CheckAnswer(true);
        SetButtonsInteractable(false, false, true);
    }

    public void ChooseMedicine()
    {
        if (timerScript.IsTimerRunning())
            timerScript.StopTimer();
        ShowDescription();
        CheckAnswer(false);
        SetButtonsInteractable(false, false, true);
    }

    public void ShowDescription()
    {
        if (wordsData != null && currentIndex >= 0 && currentIndex < wordsData.Count)
        {
            descriptionText.text = wordsData[currentIndex].description;
        }
    }

    void CheckAnswer(bool isPhilosopherSelected)
    {
        if (isPhilosopherSelected == wordsData[currentIndex].isPhilosopher)
        {
            resultTextCorrect.gameObject.SetActive(true);
            AudioManagerScript.PlayCorrectSound();
            correctAnswers++;
            CorrectAnswersCount.text = $"{correctAnswers}/{wordsCounter}";
        }
        else
        {
            resultTextWrong.gameObject.SetActive(true);
            AudioManagerScript.PlayWrongSound();
        }
    }

    public void NextWordButton()
    {
        ShowNextWord();
    }

    public void NextWordButtonTimer()
    {
        ShowNextWordWithTimer();
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ResetButton()
    {
        SceneManager.LoadScene(1);
    }

    [System.Serializable]
    public class WordData
    {
        public string word;
        public string description;
        public bool isPhilosopher;
    }

    [System.Serializable]
    public class WordList
    {
        public WordData[] words;
    }
}
