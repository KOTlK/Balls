﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BallHandler
{
    public event Action<Ball> BallCatched;
    public event Action<Ball> BallFell;
    public event Action BallRemoved;

    public void Catch(Ball ball)
    {
        BallCatched?.Invoke(ball);
        BallRemoved?.Invoke();
    }

    public void Fall(Ball ball)
    {
        BallFell?.Invoke(ball);
        BallRemoved?.Invoke();
    }
}
