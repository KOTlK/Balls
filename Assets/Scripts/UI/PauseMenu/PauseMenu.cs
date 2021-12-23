using UnityEngine;
using System;

public class PauseMenu : IWindow
{
    private readonly Canvas _canvas;
    private readonly PauseMenuData _data;
    private readonly HighScore _highScore;
    private readonly GamePause _gamePause;


    public PauseMenu(Canvas canvas, GamePause pause)
    {
        _canvas = canvas;
        _data = canvas.GetComponent<PauseMenuData>();
        _highScore = new HighScore();
        _gamePause = pause;
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
        _data.BestScore.text = $"High Score: {_highScore.TryLoad()}";
        Opened?.Invoke();
    }

    private void Subscribe()
    {
        _data.ContinueButton.onClick.AddListener(Close);
        _data.ContinueButton.onClick.AddListener(_gamePause.Unpause);
        _data.ExitButton.onClick.AddListener(Application.Quit);
    }

    private void Unsubscribe()
    {
        _data.ContinueButton.onClick.RemoveListener(Close);
        _data.ContinueButton.onClick.RemoveListener(_gamePause.Unpause);
        _data.ExitButton.onClick.RemoveListener(Application.Quit);
    }
}


