using UnityEngine;
using Extensions;
using System;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider))]
public class Ball : MonoBehaviour, IPoolable
{
    private SpriteRenderer _renderer;
    private Color _ballColor;
    private float _ballRadius;
    private LifeStatus _status;
    private Falling _falling;
    private int _id;
    private BallInitialData _data;
    private Score _score;
    private int _scoreForCatch;

    private Particles _particles;

    public event Action Catched;
    public event Action Disposed;

    public LifeStatus Status => _status;
    public int ID => _id;

    private Pool<Ball> ActiveBalls => _data.Pool.ActiveBalls;
    private Pool<Ball> InactiveBalls => _data.Pool.InactiveBalls;


    public void Init(BallInitialData data)
    {
        _data = data;
        _particles = _data.Particles;
        _falling = new Falling(UnityEngine.Random.Range(1f, 3f), this.transform, _data.Difficulty);
        _score = data.Score;
    }

    public void Catch()
    {
        Catched?.Invoke();
        _score.Increase(_scoreForCatch);
    }


    public void Dispose()
    {
        Disposed?.Invoke();
    }

    public void Activate()
    {
        if (InactiveBalls.Exist(_id))
        {
            InactiveBalls.RemoveByIndex(_id);
        }

        _id = ActiveBalls.Add(this);
        this.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        if (ActiveBalls.Exist(_id))
        {
            ActiveBalls.RemoveByIndex(_id);
        }
        _id = InactiveBalls.Add(this);
        this.gameObject.SetActive(false);
    }

    private void PlayParticles()
    {
        _particles.Play(this.transform.position, _ballColor);
    }

    #region Unity methods

    private void Awake()
    {
        _renderer = this.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        _falling.Update();
    }

    private void OnEnable()
    {
        _status = LifeStatus.Alive;
        _ballRadius = UnityEngine.Random.Range(1f, 3f);
        this.transform.localScale = new Vector2(_ballRadius, _ballRadius);
        _ballColor = _ballColor.GetRandomColor();
        _renderer.material.color = _ballColor;

        _scoreForCatch = (int)(UnityEngine.Random.Range(3, 12) / _ballRadius);

        Catched += PlayParticles;
        Catched += Deactivate;

        Disposed += Deactivate;
    }

    private void OnDisable()
    {
        _status = LifeStatus.Dead;

        Catched -= PlayParticles;
        Catched -= Deactivate;

        Disposed -= Deactivate;
    }


    private void OnMouseDown()
    {
        if (_status == LifeStatus.Alive)
        {
            Catch();
        }

    }
    #endregion

    

}




public enum LifeStatus
{
    Alive,
    Dead
}

public struct BallInitialData
{
    public IDifficulty Difficulty;
    public ObjectsPool Pool;
    public Particles Particles;
    public Score Score;
}

