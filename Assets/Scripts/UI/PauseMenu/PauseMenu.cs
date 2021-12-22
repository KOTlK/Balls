using UnityEngine;
using System;

public class PauseMenu : IWindow
{
    private readonly Canvas _canvas;
    private readonly PauseMenuData _data;
    private readonly GamePause _pause;

    public event Action Opened;
    public event Action Closed;

    public PauseMenu(Canvas canvas, GamePause pause)
    {
        _canvas = canvas;
        _data = canvas.GetComponent<PauseMenuData>();
        _pause = pause;
        Subscribe();
    }

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
        Opened?.Invoke();
    }

    private void Subscribe()
    {
        _data.ContinueButton.onClick.AddListener(_pause.Unpause);
        _data.ContinueButton.onClick.AddListener(Close);
        _data.ExitButton.onClick.AddListener(Application.Quit);
    }

    private void Unsubscribe()
    {
        _data.ContinueButton.onClick.RemoveListener(_pause.Unpause);
        _data.ContinueButton.onClick.RemoveListener(Close);
        _data.ExitButton.onClick.RemoveListener(Application.Quit);
    }
}


