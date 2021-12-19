using System;

public class Hp
{
    private const int MaxHp = 100;
    private int _hp;

    public event Action HpChanged;
    public event Action HpOver;

    public Hp()
    {
        _hp = MaxHp;
    }

    public int CurrentHp => _hp;

    public void Decrese(Ball ball)
    {
        _hp -= ball.HpforFall;
        if (_hp <= 0)
        {
            HpOver?.Invoke();
        }
        HpChanged?.Invoke();
    }
}
