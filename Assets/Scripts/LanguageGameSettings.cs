using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LanguageGameSettings : MonoBehaviour
{
    public TextMeshProUGUI wordText;
    public TextMeshProUGUI Description;
    public TextMeshProUGUI Philosopher;
    public TextMeshProUGUI Medecin;
    public TextMeshProUGUI Next;
    public TextMeshProUGUI Menu;
    public TextMeshProUGUI ResultCorrect;
    public TextMeshProUGUI ResultWrong;
    public TextMeshProUGUI TimeUp;
    public TextMeshProUGUI PlayerLabel;
    public TextMeshProUGUI YourResult;

    public TMP_FontAsset LabelFont;
    public TMP_FontAsset LabelFontCh;
    public TMP_FontAsset ButtonFont;
    public TMP_FontAsset ButtonFontCh;
    public TMP_FontAsset CursiveFont;
    public TMP_FontAsset CursiveFontCh;

    private string playerName;

    void Start()
    {
        playerName = PlayerPrefs.GetString("playerName", "Anonimus");
        SetLanguage();
    }

    public void ChangeLanguage(Language language)
    {

        switch (language)
        {
            case Language.Ukrainian:
                ChangeFont(wordText, LabelFont);
                Philosopher.text = "Філософ";
                ChangeFont(Philosopher, LabelFont);
                Medecin.text = "Ліки";
                ChangeFont(Medecin, LabelFont);
                Next.text = "Далі";
                ChangeFont(Next, ButtonFont);
                Menu.text = "Меню";
                ChangeFont(Menu, ButtonFont);
                ResultCorrect.text = "Вірно!";
                ChangeFont(ResultCorrect, ButtonFont);
                ResultWrong.text = "Невірно.";
                ChangeFont(ResultWrong, ButtonFont);
                TimeUp.text = "Час вийшов";
                ChangeFont(TimeUp, ButtonFont);
                PlayerLabel.text = $"Вітаю \n{playerName}";
                ChangeFont(PlayerLabel, LabelFont);
                YourResult.text = "Твій результат:";
                ChangeFont(YourResult, CursiveFont);
                ChangeFont(Description, CursiveFont);
                break;
            case Language.China:
                ChangeFont(wordText, LabelFontCh);
                Philosopher.text = "哲学家";
                ChangeFont(Philosopher, LabelFontCh);
                Medecin.text = "药品";
                ChangeFont(Medecin, LabelFontCh);
                Next.text = "更远";
                ChangeFont(Next, ButtonFontCh);
                Menu.text = "菜单";
                ChangeFont(Menu, ButtonFontCh);
                ResultCorrect.text = "正确的！";
                ChangeFont(ResultCorrect, ButtonFontCh);
                ResultWrong.text = "错误的。";
                ChangeFont(ResultWrong, ButtonFontCh);
                TimeUp.text = "时间到";
                ChangeFont(TimeUp, ButtonFontCh);
                PlayerLabel.text = $"恭喜 \n{playerName}";
                ChangeFont(PlayerLabel, LabelFontCh);
                YourResult.text = "你的结果:";
                ChangeFont(YourResult, ButtonFontCh);
                ChangeFont(Description, CursiveFontCh);
                break;
            default:
                ChangeFont(wordText, LabelFont);
                Philosopher.text = "Philosopher";
                ChangeFont(Philosopher, LabelFont);
                Medecin.text = "Medicine";
                ChangeFont(Medecin, LabelFont);
                Next.text = "Next";
                ChangeFont(Next, ButtonFont);
                Menu.text = "Menu";
                ChangeFont(Menu, ButtonFont);
                ResultCorrect.text = "Correct!";
                ChangeFont(ResultCorrect, ButtonFont);
                ResultWrong.text = "Wrong.";
                ChangeFont(ResultWrong, ButtonFont);
                TimeUp.text = "Time is over";
                ChangeFont(TimeUp, ButtonFont);
                PlayerLabel.text = $"Congratulation \n{playerName}";
                ChangeFont(PlayerLabel, LabelFont);
                YourResult.text = "Your result:";
                ChangeFont(YourResult, CursiveFont);
                ChangeFont(Description, CursiveFont);
                break;
        }

    }

    private void SetLanguage()
    {
        string language = PlayerPrefs.GetString("Language", "en-US");

        switch (language)
        {
            case "uk-UA":
                ChangeLanguage(Language.Ukrainian);
                break;
            case "zh-CN":
                ChangeLanguage(Language.China);
                break;
            default:
                ChangeLanguage(Language.English);
                break;
        }
    }

    private void ChangeFont(TextMeshProUGUI textMeshProUGUI, TMP_FontAsset newFont)
    {
        if (textMeshProUGUI != null && newFont != null)
        {
            textMeshProUGUI.font = newFont;
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI component or new font is missing.");
        }
    }
}

