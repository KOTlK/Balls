using UnityEngine;

public class Falling : IUpdatable
{
    private readonly float _speed;
    private readonly Transform _body;
    private readonly IDifficulty _difficulty;

    public Falling(float speed, Transform body, IDifficulty difficulty)
    {
        _speed = speed;
        _body = body;
        _difficulty = difficulty;
    }

    public void Update()
    {
        _body.transform.Translate(new Vector3(0, -_speed * _difficulty.DifficultyMultiplier * Time.deltaTime, 0));
    }

}
