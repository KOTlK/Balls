using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BallsSpawner : IUpdatable
{
    private readonly BallsFactory _factory;
    private readonly BallDestroyer _destroyer;
    private readonly Respawner _respawner;

    public BallsSpawner(SpawnerData data)
    {
        _factory = new BallsFactory(data.Parent, data.Prefab, data.InitialData);
        _destroyer = new BallDestroyer(data.InitialData.Pool);
        _respawner = new Respawner(data.MaxBallsOnScreen, _factory, data.MinXSpawnPositon, data.MaxXSpawnPositon, data.YPosition);
        data.BallHandler.BallRemoved += _respawner.DecreaseAmount;
        _factory.CacheObjects(data.MaxBallsAmount);
    }

    public void Update()
    {
        _destroyer.Update();
        _respawner.Update();
    }


}


public struct SpawnerData
{
    public Transform Parent;
    public GameObject Prefab;
    public BallInitialData InitialData;
    public int MaxBallsOnScreen;
    public float MinXSpawnPositon;
    public float MaxXSpawnPositon;
    public float YPosition;
    public int MaxBallsAmount;
    public BallHandler BallHandler;
}
