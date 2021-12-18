using System.Collections;
using UnityEngine;

public class PauseMenu : IWindow
{
    private readonly Canvas _canvas;

    public PauseMenu(Canvas canvas)
    {
        _canvas = canvas;
    }

    public void Close()
    {
        _canvas.enabled = false;
    }

    public void Open()
    {
        _canvas.enabled = true;
    }
}