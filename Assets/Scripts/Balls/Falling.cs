using UnityEngine;

public class Falling : IUpdatable
{
    private readonly float _speed;
    private readonly Transform _body;
    private readonly IDifficulty _difficulty;
    private float _currentSpeed;

    public Falling(float speed, Transform body, IDifficulty difficulty)
    {
        _speed = speed;
        _currentSpeed = _speed;
        _body = body;
        _difficulty = difficulty;
    }

    public void Update()
    {
        _body.transform.Translate(new Vector3(0, -_currentSpeed * _difficulty.DifficultyMultiplier * Time.deltaTime, 0));
    }

    public void StopFalling()
    {
        _currentSpeed = 0;
    }

    public void StartFalling()
    {
        _currentSpeed = _speed;
    }

}
