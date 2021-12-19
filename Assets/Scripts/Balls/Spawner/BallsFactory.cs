using UnityEngine;
using System;

public class BallsFactory
{
    private readonly Transform _parent;
    private readonly GameObject _prefab;
    private readonly Vector2 _cachePoint;
    private readonly BallInitialData _ballData;

    public BallsFactory(Transform parent, GameObject prefab, BallInitialData ballData)
    {
        _ballData = ballData;
        _parent = parent;
        _prefab = prefab;
        _cachePoint = new Vector2(9999, 9999);
    }

    public void CacheObjects(int amount)
    {
        while ( amount > 0)
        {
            var ballobject = MonoBehaviour.Instantiate(_prefab, _cachePoint, Quaternion.identity, _parent);
            var ballComponent = ballobject.GetComponent<Ball>();
            ballComponent.Init(_ballData);
            ballComponent.Deactivate();
            amount--;
        }
    }

    public Ball SpawnAt(Vector2 position)
    {
        var ball = _ballData.Pool.InactiveBalls.First;
        ball.transform.position = position;
        ball.Activate();
        return ball;
    }



}
