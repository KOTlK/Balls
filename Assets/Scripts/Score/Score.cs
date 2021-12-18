using System;

public class Score
{
    private int _score;

    public event Action<Score> ScoreChanged;

    public Score()
    {
        _score = 0;
    }

    public int CurrentScore => _score;

    public void Increase(int amount)
    {
        _score += amount;
        ScoreChanged?.Invoke(this);
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(this);
    }

}
