using Extensions;
using UnityEngine;

public class BallDestroyer : IUpdatable
{
    private const float YOffset = 2f;
    private readonly Camera _camera;
    private readonly float _destroyCoordinate;
    private readonly ObjectsPool _pool;

    private Ball[] Balls => _pool.ActiveBalls.AllObjects;


    public BallDestroyer(ObjectsPool pool)
    {
        _pool = pool;
        _camera = Camera.main;
        _destroyCoordinate = _camera.GetMinBounds().y;
    }

    public void Update()
    {
        foreach (var ball in Balls)
        {
            if(ball.transform.position.y < _destroyCoordinate - YOffset)
            {
                ball.Dispose();
            }
        }
    }
}