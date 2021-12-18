using UnityEngine;
using System;
public class IncreaseDifficultyByTime : IDifficulty
{
    private readonly GameTick _gameTime;
    private readonly int _seconds = 3;
    private float _difficultyMultiplier = 1;
    private int _cachedTick = 0;

    public IncreaseDifficultyByTime(int seconds, GameTick ticks)
    {
        _seconds = seconds;
        _gameTime = ticks;
    }

    public float DifficultyMultiplier => _difficultyMultiplier;

    public void Update()
    {
        if ((int)_gameTime.Tick % _seconds == 0 && (int)_gameTime.Tick != _cachedTick)
        {
            _difficultyMultiplier += 0.1f;
            _cachedTick = (int)_gameTime.Tick;
        }
    }
}
