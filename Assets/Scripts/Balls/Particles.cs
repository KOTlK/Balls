using System.Collections.Generic;
using UnityEngine;

public class Particles
{
    private readonly ParticleSystem _prefab;
    private readonly Queue<ParticleSystem> _particles;
    private readonly Transform _parent;
    private int _amountToSpawn;

    public Particles(int amount, ParticleSystem prefab, Transform parent)
    {
        _parent = parent;
        _particles = new Queue<ParticleSystem>();
        _amountToSpawn = amount;
        _prefab = prefab;
    }

    public void Play(Vector2 position, Color color)
    {
        var particle = TryDequeue();
        var main = particle.main;
        main.startColor = color;
        particle.transform.position = position;
        particle.Play();
        _particles.Enqueue(particle);
    }

    public void Init()
    {
        while(_amountToSpawn > 0)
        {
            var obj = MonoBehaviour.Instantiate(_prefab, _parent);
            _particles.Enqueue(obj);
            _amountToSpawn--;
        }
    }

    private ParticleSystem TryDequeue()
    {
        var particle = _particles.Dequeue();
        if (particle.isPlaying)
        {
            _particles.Enqueue(particle);
            return TryDequeue();
        } else
        {
            return particle;
        }
    }


}