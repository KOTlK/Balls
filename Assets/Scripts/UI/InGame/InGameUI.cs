using UnityEngine;

public class InGameUI : IWindow
{
    private readonly InGameUIModel _model;
    private readonly InGameUIController _controller;
    private readonly InGameUIView _view;


    public InGameUI(Canvas canvas, InGameUIData data, OnScreenData screenData)
    {
        _model = new InGameUIModel();
        _view = new InGameUIView(_model, canvas, data);
        _controller = new InGameUIController(_model, screenData);
        screenData.Score.ScoreChanged += _controller.UpdateUI;
        screenData.HP.HpChanged += _controller.UpdateUI;
    }

    public void Open() => _controller.Open();

    public void Close() => _controller.Close();
}

public struct OnScreenData
{
    public Score Score;
    public Hp HP;
}
