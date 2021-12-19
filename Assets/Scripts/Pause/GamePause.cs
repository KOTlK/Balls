using System.Collections.Generic;

public class GamePause
{
    private List<IPausable> _pausables;
    private bool _paused;

    public GamePause()
    {
        _pausables = new List<IPausable>();
        _paused = false;
    }

    public bool isPaused => _paused;

    public void Pause()
    {
        foreach(IPausable p in _pausables)
        {
            p.Pause();
        }
        _paused = true;
    }

    public void Unpause()
    {
        foreach (IPausable p in _pausables)
        {
            p.Unpause();
        }
        _paused = false;
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
