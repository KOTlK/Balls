using UnityEngine;
using System;

public class InGameUI : IWindow
{
    private readonly InGameUIModel _model;
    private readonly InGameUIController _controller;
    private readonly InGameUIView _view;
    private readonly InGameUIData _uiData;
    private readonly InGameUIInitialData _uiInitialData;

    public InGameUI(InGameUIInitialData data)
    {
        _uiInitialData = data;
        _uiData = _uiInitialData.Canvas.GetComponent<InGameUIData>();
        _model = new InGameUIModel();
        _view = new InGameUIView(_model, _uiInitialData.Canvas, _uiData);
        _controller = new InGameUIController(_model, _uiInitialData.ScreenData);
        AddListeners();
    }

    public event Action Opened;
    public event Action Closed;

    public void Open()
    {
        _controller.Open();
        Opened?.Invoke();
        AddListeners();
    } 

    public void Close()
    {
        _controller.Close();
        Closed?.Invoke();
        RemoveListeners();
    }

    private void AddListeners()
    {
        _uiData.MenuButton.onClick.AddListener(_uiInitialData.GamePause.Pause);
        _uiData.MenuButton.onClick.AddListener(Close);
        _uiInitialData.ScreenData.Score.ScoreChanged += _controller.UpdateUI;
        _uiInitialData.ScreenData.HP.HpChanged += _controller.UpdateUI;
    }

    private void RemoveListeners()
    {
        _uiData.MenuButton.onClick.RemoveListener(_uiInitialData.GamePause.Pause);
        _uiData.MenuButton.onClick.RemoveListener(Close);
        _uiInitialData.ScreenData.Score.ScoreChanged -= _controller.UpdateUI;
        _uiInitialData.ScreenData.HP.HpChanged -= _controller.UpdateUI;
    }


    
}

public struct OnScreenData
{
    public Score Score;
    public Hp HP;
}

public struct InGameUIInitialData
{
    public Canvas Canvas;
    public OnScreenData ScreenData;
    public GamePause GamePause;
}
