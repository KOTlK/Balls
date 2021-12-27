using UnityEngine;
using System;

public class PauseMenu : IWindow
{
    private readonly Canvas _canvas;
    private readonly PauseMenuData _data;
    private readonly HighScore _highScore;
    private readonly GamePause _gamePause;
    private readonly Localization _localization;


    public PauseMenu(Canvas canvas, GamePause pause, Localization local)
    {
        _canvas = canvas;
        _data = canvas.GetComponent<PauseMenuData>();
        _highScore = new HighScore();
        _gamePause = pause;
        _localization = local;
        Subscribe();
    }

    public event Action Opened;
    public event Action Closed;

    public void Close()
    {
        _canvas.enabled = false;
        Unsubscribe();
        Closed?.Invoke();
    }

    public void Open()
    {
        _canvas.enabled = true;
        Subscribe();
        UpdateInfo();
        Opened?.Invoke();
    }

    private void UpdateInfo()
    {
        _data.BestScore.text = $"{_localization.FindString(_data.BestScore.name)}: {_highScore.TryLoad()}";
        _data.ExitButtonText.text = $"{_localization.FindString(_data.ExitButtonText.name)}";
        _data.ContinueButtonText.text = $"{_localization.FindString(_data.ContinueButtonText.name)}";
    }

    private void Subscribe()
    {
        _data.ContinueButton.onClick.AddListener(Close);
        _data.ContinueButton.onClick.AddListener(_gamePause.Unpause);
        _data.ExitButton.onClick.AddListener(Application.Quit);
        _localization.LanguageChanged += UpdateInfo;
        _data.English.onClick.AddListener(delegate { _localization.ChangeLanguage(Languages.English); });
        _data.Russian.onClick.AddListener(delegate { _localization.ChangeLanguage(Languages.Russian); });
    }

    private void Unsubscribe()
    {
        _data.ContinueButton.onClick.RemoveListener(Close);
        _data.ContinueButton.onClick.RemoveListener(_gamePause.Unpause);
        _data.ExitButton.onClick.RemoveListener(Application.Quit);
        _localization.LanguageChanged -= UpdateInfo;
        _data.English.onClick.RemoveListener(delegate { _localization.ChangeLanguage(Languages.English); });
        _data.Russian.onClick.RemoveListener(delegate { _localization.ChangeLanguage(Languages.Russian); });
    }
}


