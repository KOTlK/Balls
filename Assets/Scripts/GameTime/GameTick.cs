using UnityEngine;
using System;

public class GameTick : IUpdatable
{
    private float _tick = 0;

    public float Tick => _tick;

    public void Reset()
    {
        _tick = 0;
    }

    public void Update()
    {
        _tick += Time.deltaTime;
    }

}
