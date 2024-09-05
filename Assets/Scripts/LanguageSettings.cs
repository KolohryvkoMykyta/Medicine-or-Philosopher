using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSettings : MonoBehaviour
{
    public TextMeshProUGUI GameLabel;
    public TextMeshProUGUI PlayButton;
    public TextMeshProUGUI OptionButton;
    public TextMeshProUGUI RecordsButton;
    public TextMeshProUGUI DescriptionButton;
    public TextMeshProUGUI ExitButton;
    public TextMeshProUGUI SettingsLabel;
    public TextMeshProUGUI Volume;
    public TextMeshProUGUI LanguageLabel;
    public TextMeshProUGUI OptionBackButton;
    public TextMeshProUGUI RecordsLabel;
    public TextMeshProUGUI RecordsBackButton;
    public TextMeshProUGUI RecordsClearButton;
    public TextMeshProUGUI DescriptionLabel;
    public TextMeshProUGUI Description;
    public TextMeshProUGUI DescriptionBackButton;
    public TextMeshProUGUI InputPlayerName;
    public TextMeshProUGUI ArcadeMode;
    public TextMeshProUGUI PracticeMode;
    public TextMeshProUGUI Menu;
    public TextMeshProUGUI LinkToAuthor;
    public TMP_InputField InputName;
    public TMP_Dropdown DropdownLanguage;
    public TextMeshProUGUI[] PlayerNames;

    public TMP_FontAsset LabelFont;
    public TMP_FontAsset LabelFontCh;
    public TMP_FontAsset ButtonFont;
    public TMP_FontAsset ButtonFontCh;
    public TMP_FontAsset CursiveFont;
    void Start()
    {
        SetLanguage();
    }

    public void ChangeLanguage(int language)
    {
        ChangeLanguage((Language)language);
    }
    public void ChangeLanguage(Language language)
    {
        
        switch (language)
        {
            case Language.Ukrainian:
                PlayerPrefs.SetString("Language", "uk-UA");
                GameLabel.text = "Ліки чи філософ";
                GameLabel.font = LabelFont;
                PlayButton.text = "Грати";
                PlayButton.font = ButtonFont;
                OptionButton.text = "Опції";
                OptionButton.font = ButtonFont;
                RecordsButton.text = "Рекорди";
                RecordsButton.font = ButtonFont;
                DescriptionButton.text = "Опис";
                DescriptionButton.font = ButtonFont;
                ExitButton.text = "Вихід";
                ExitButton.font = ButtonFont;
                SettingsLabel.text = "Налаштування";
                SettingsLabel.font = LabelFont;
                Volume.text = "Звук";
                Volume.font = ButtonFont;
                LanguageLabel.text = "Мова";
                LanguageLabel.font = ButtonFont;
                OptionBackButton.text = "Назад";
                OptionBackButton.font = ButtonFont;
                RecordsLabel.text = "Таблиця Рекордів";
                RecordsLabel.font = LabelFont;
                ChangeFontForArray(PlayerNames, CursiveFont);
                RecordsBackButton.text = "Назад";
                RecordsBackButton.font = ButtonFont;
                RecordsClearButton.text = "Очистити";
                RecordsClearButton.font = ButtonFont;
                DescriptionLabel.text = "Опис";
                DescriptionLabel.font = LabelFont;
                Description.text = "    \"Ліки чи Філософ\" - захоплююча гра, що викликає гравців перевірити свої знання в галузях " +
                    "філософії та медицини. У грі з'являються слова, і гравцям потрібно вгадати, чи є кожне слово ім'ям філософа " +
                    "чи назвою лікарського засобу.\n\nАркадний режим: \nВгадайте з 20 слів - Гравці вирішують, чи кожне з 20 слів, що " +
                    "відображаються, є ім'ям філософа чи назвою лікарського засобу. Вони намагаються зробити якомога більше " +
                    "правильних відповідей протягом обмеженого часу.\n\nТренувальний режим: \nРежим тренування - Гравці можуть вдосконалювати " +
                    "свої навички у будь-який час, без обмежень за часом чи кількістю слів. Нескінченно генеровані слова " +
                    "дозволяють гравцям вправлятися вгадувати без часового тиску.";
                Description.font = ButtonFont;
                DescriptionBackButton.text = "Назад";
                DescriptionBackButton.font = ButtonFont;
                InputPlayerName.text = "Введіть Ім'я Гравця";
                InputPlayerName.font = LabelFont;
                ArcadeMode.text = "Аркада";
                ArcadeMode.font = ButtonFont;
                PracticeMode.text = "Тренування";
                PracticeMode.font = ButtonFont;
                Menu.text = "Меню";
                Menu.font = ButtonFont;
                LinkToAuthor.text = "Автор гри:";
                LinkToAuthor.font = ButtonFont;
                InputName.textComponent.font = ButtonFont;
                break;
            case Language.China:
                PlayerPrefs.SetString("Language", "zh-CN");
                GameLabel.text = "医学或哲学家";
                GameLabel.font = LabelFontCh;
                PlayButton.text = "玩";
                PlayButton.font= ButtonFontCh;
                OptionButton.text = "选项";
                OptionButton.font = ButtonFontCh;
                RecordsButton.text = "记录";
                RecordsButton.font = ButtonFontCh;
                DescriptionButton.text = "描述";
                DescriptionButton.font= ButtonFontCh;
                ExitButton.text = "出口";
                ExitButton.font = ButtonFontCh;
                SettingsLabel.text = "设置";
                SettingsLabel.font = LabelFontCh;
                Volume.text = "体积";
                Volume.font= ButtonFontCh;
                LanguageLabel.text = "语言";
                LanguageLabel.font= ButtonFontCh;
                OptionBackButton.text = "后退";
                OptionBackButton.font= ButtonFontCh;
                RecordsLabel.text = "记录表";
                RecordsLabel.font = LabelFontCh;
                ChangeFontForArray(PlayerNames, ButtonFontCh);
                RecordsBackButton.text = "后退";
                RecordsBackButton.font = ButtonFontCh;
                RecordsClearButton.text = "清除";
                RecordsClearButton.font = ButtonFontCh;
                DescriptionLabel.text = "描述";
                DescriptionLabel.font = LabelFontCh;
                Description.text = "    “药品还是哲学家”是一款令人兴奋的游戏，挑战玩家测试他们在哲学和医学领域的知识。游戏中会出现单词，" +
                    "玩家需要猜测每个单词是哲学家的名字还是药品的名称。\n\n街机模式：\n猜测20个单词 - 玩家决定每个出现的20个单词是哲学" +
                    "家的名字还是药品的名称。他们努力在有限的时间内做出尽可能多的正确猜测。\n\n练习模式：\n练习模式 - 玩家可以随时练习" +
                    "他们的技能，没有时间限制或单词数量限制。无限生成的单词让玩家可以在没有时间压力的情况下练习猜测。";
                Description.font = ButtonFontCh;
                DescriptionBackButton.text = "后退";
                DescriptionBackButton.font = ButtonFontCh;
                InputPlayerName.text = "输入玩家姓名";
                InputPlayerName.font = LabelFontCh;
                ArcadeMode.text = "街机模式";
                ArcadeMode.font = ButtonFontCh;
                PracticeMode.text = "练习模式";
                PracticeMode.font = ButtonFontCh;
                Menu.text = "菜单";
                Menu.font = ButtonFontCh;
                LinkToAuthor.text = "游戏作者：";
                LinkToAuthor.font = ButtonFontCh;
                InputName.textComponent.font = ButtonFontCh;
                break;
            default:
                PlayerPrefs.SetString("Language", "en-US");
                GameLabel.text = "Medicine or Philosopher";
                GameLabel.font = LabelFont;
                PlayButton.text = "Play";
                PlayButton.font = ButtonFont;
                OptionButton.text = "Options";
                OptionButton.font = ButtonFont;
                RecordsButton.text = "Records";
                RecordsButton.font = ButtonFont;
                DescriptionButton.text = "Description";
                DescriptionButton.font = ButtonFont;
                ExitButton.text = "Exit";
                ExitButton.font = ButtonFont;
                SettingsLabel.text = "Settings";
                SettingsLabel.font= LabelFont;
                Volume.text = "Volume";
                Volume.font= ButtonFont;
                LanguageLabel.text = "Language";
                LanguageLabel.font = ButtonFont;
                OptionBackButton.text = "Back";
                OptionBackButton.font = ButtonFont;
                RecordsLabel.text = "Table of records";
                RecordsLabel.font = LabelFont;
                ChangeFontForArray(PlayerNames, CursiveFont);
                RecordsBackButton.text = "Back";
                RecordsBackButton.font = ButtonFont;
                RecordsClearButton.text = "Clear";
                RecordsClearButton.font = ButtonFont;
                DescriptionLabel.text = "Description";
                DescriptionLabel.font = LabelFont;
                Description.text = "    \"Medicine or Philosopher\" is an exciting game that challenges players to test their " +
                    "knowledge in the fields of philosophy and medicine. Words appear in the game, and players must guess " +
                    "whether each word is the name of a philosopher or the name of a medicine.\n\nArcade Mode:\nGuess from " +
                    "20 words - Players decide if each of the 20 words presented is a philosopher's name or a medicine. " +
                    "They strive to make as many correct guesses as possible within a limited time.\n\nPractice Mode:\n" +
                    "Practice mode - Players can hone their skills anytime without time or word restrictions. Endlessly " +
                    "generated words let players practice guessing without time pressure.";
                Description.font = ButtonFont;
                DescriptionBackButton.text = "Back";
                DescriptionBackButton.font = ButtonFont;
                InputPlayerName.text = "Input Player Name";
                InputPlayerName.font = LabelFont;
                ArcadeMode.text = "Arcade Mode";
                ArcadeMode.font = ButtonFont;
                PracticeMode.text = "Practice Mode";
                PracticeMode.font = ButtonFont;
                Menu.text = "Menu";
                Menu.font = ButtonFont;
                LinkToAuthor.text = "Game by: ";
                LinkToAuthor.font = ButtonFont;
                InputName.textComponent.font = ButtonFont;
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
                DropdownLanguage.value = (int)Language.Ukrainian;
                break;
            case "zh-CN":
                ChangeLanguage(Language.China);
                DropdownLanguage.value = (int)Language.China;
                break;
            default:
                ChangeLanguage(Language.English);
                DropdownLanguage.value = (int)Language.English;
                break;
        }
    }

    private void ChangeFontForArray(TextMeshProUGUI[] textMeshProUGUIArray, TMP_FontAsset newFont)
    {
        foreach (var TMP in textMeshProUGUIArray)
            TMP.font = newFont;
    }
}

    public enum Language
    {
        English,
        Ukrainian,
        China
    }
