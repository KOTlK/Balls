using UnityEngine;

public class ObjectsPool
{
    private readonly Pool<Ball> _activeBalls;
    private readonly Pool<Ball> _inactiveBalls;

    public ObjectsPool()
    {
        _activeBalls = new Pool<Ball>();
        _inactiveBalls = new Pool<Ball>();
    }

    public Pool<Ball> ActiveBalls => _activeBalls;
    public Pool<Ball> InactiveBalls => _inactiveBalls;

}
