using UnityEngine;

class Respawner : IUpdatable
{
    private readonly int _maxAmountOnScreen;
    private readonly float _yPosition;
    private int _currentAmount = 0;

    private readonly BallsFactory _factory;
    private readonly Vector2 _xRestrictions;

    public Respawner(int maxAmountOnScreen, BallsFactory factory, float minXPosition, float maxXPosition, float yPosition)
    {
        _maxAmountOnScreen = maxAmountOnScreen;
        _factory = factory;
        _xRestrictions = new Vector2(minXPosition, maxXPosition);
        _yPosition = yPosition;
    }

    public void Update()
    {
        if (_currentAmount < _maxAmountOnScreen)
        {
            SpawnBall();
            _currentAmount++;
        }
    }

    private void SpawnBall()
    {
        var position = new Vector2(Random.Range(_xRestrictions.x, _xRestrictions.y), _yPosition);
        var ball = _factory.SpawnAt(position);
    }

    public void DecreaseAmount()
    {
        _currentAmount--;
    }
}
