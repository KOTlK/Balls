using System;
using UnityEngine;

public class InGameUI
{
    private readonly InGameUIModel _model;
    private readonly InGameUIController _controller;
    private readonly InGameUIView _view;

    public InGameUIController Controller => _controller;

    public InGameUI(Canvas canvas, InGameUIData data, OnScreenData screenData)
    {
        _model = new InGameUIModel();
        _view = new InGameUIView(_model, canvas, data);
        _controller = new InGameUIController(_model);
        screenData.Score.ScoreChanged += _controller.UpdateScore;
    }
}
