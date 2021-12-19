using System;

public class Score
{
    private int _score;

    public event Action ScoreChanged;

    public Score()
    {
        _score = 0;
    }

    public int CurrentScore => _score;

    public void Increase(Ball ball)
    {
        _score += ball.ScoreForCatch;
        ScoreChanged?.Invoke();
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke();
    }

}
