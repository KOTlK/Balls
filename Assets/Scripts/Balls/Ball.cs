using UnityEngine;
using Extensions;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider))]
public class Ball : MonoBehaviour, IPoolable
{
    private BallInitialData _data;
    private SpriteRenderer _renderer;
    private Falling _falling;
    private Particles _particles;
    private BallHandler _handler;

    private Color _ballColor;
    private float _ballRadius;
    private LifeStatus _status;
    private int _id;
    private int _scoreForCatch;
    private int _hpForFall;

    public int ID => _id;
    public int ScoreForCatch => _scoreForCatch;
    public int HpforFall => _hpForFall;

    private Pool<Ball> ActiveBalls => _data.Pool.ActiveBalls;
    private Pool<Ball> InactiveBalls => _data.Pool.InactiveBalls;


    public void Init(BallInitialData data)
    {
        _data = data;
        _particles = _data.Particles;
        _handler = data.BallHandler;
        _falling = new Falling(UnityEngine.Random.Range(1f, 3f), this.transform, _data.Difficulty);
    }


    public void Fall()
    {
        _handler.Fall(this);
        Deactivate();
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

    private void Catch()
    {
        _handler.Catch(this);
        PlayParticles();
        Deactivate();
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

        _scoreForCatch = (int)(UnityEngine.Random.Range(3, 12) / _ballRadius); // smaller ball => more score
        _hpForFall = (int)(UnityEngine.Random.Range(5, 10) * _ballRadius); // bigger ball fell => more score lose

    }

    private void OnDisable()
    {
        _status = LifeStatus.Dead;
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
    public BallHandler BallHandler;
}

