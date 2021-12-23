using System.Collections.Generic;
using System;

public class GamePause
{
    private List<IPausable> _pausables;
    private bool _paused;

    public GamePause()
    {
        _pausables = new List<IPausable>();
        _paused = false;
    }

    public event Action GamePaused;
    public event Action GameResume;

    public bool isPaused => _paused;

    public void Pause()
    {
        foreach(IPausable p in _pausables)
        {
            p.Pause();
        }
        _paused = true;
        GamePaused?.Invoke();
    }

    public void Unpause()
    {
        foreach (IPausable p in _pausables)
        {
            p.Unpause();
        }
        _paused = false;
        GameResume?.Invoke();
    }

    public void AddPauasble(IPausable pausable)
    {
        _pausables.Add(pausable);
    }

    public void Clear()
    {
        _pausables.Clear();
    }
}
