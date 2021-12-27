using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : IWindow
{
    private readonly LoseScreenInitialData _initData;
    private readonly LoseScreenUIData _uiData;
    private readonly HighScore _highScore;

    public LoseScreen(LoseScreenInitialData data)
    {
        _initData = data;
        _uiData = _initData.Canvas.GetComponent<LoseScreenUIData>();
        _highScore = new HighScore();
        _initData.Hp.HpOver += Open;
    }

    public event Action Opened;
    public event Action Closed;

    public void Close()
    {
        _initData.Canvas.enabled = false;
        _initData.Localization.LanguageChanged -= UpdateInfo;
        Closed?.Invoke();
    }

    public void Open()
    {
        _initData.Canvas.enabled = true;
        Opened?.Invoke();
        _initData.Localization.LanguageChanged += UpdateInfo;
        UpdateInfo();
        _uiData.Retry.onClick.AddListener(ReloadScene);
    }

    private void UpdateInfo()
    {
        _uiData.Lose.text = _initData.Localization.FindString(_uiData.Lose.name);
        _uiData.CurrentScore.text = $"{_initData.Localization.FindString(_uiData.CurrentScore.name)}: {_initData.Score.CurrentScore}";
        _uiData.BestScore.text = $"{_initData.Localization.FindString(_uiData.BestScore.name)}: {_highScore.TryLoad()}";
    }

    private void ReloadScene() // for tests only*
    {
        SceneManager.LoadScene(0);
    }

}

public struct LoseScreenInitialData
{
    public Canvas Canvas;
    public Score Score;
    public Hp Hp;
    public Localization Localization;
}


//*I lied