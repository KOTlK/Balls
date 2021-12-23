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
        Closed?.Invoke();
    }

    public void Open()
    {
        _initData.Canvas.enabled = true;
        Opened?.Invoke();
        UpdateInfo();
        _uiData.Retry.onClick.AddListener(ReloadScene);
    }

    private void UpdateInfo()
    {
        _uiData.Lose.text = "You Lose!";
        _uiData.CurrentScore.text = $"Your Score: {_initData.Score.CurrentScore}";
        _uiData.BestScore.text = $"Best score: {_highScore.TryLoad()}";
    }

    private void ReloadScene() // for tests only
    {
        SceneManager.LoadScene(0);
    }

}

public struct LoseScreenInitialData
{
    public Canvas Canvas;
    public Score Score;
    public Hp Hp;
}
