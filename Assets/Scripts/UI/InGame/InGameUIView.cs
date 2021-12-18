using UnityEngine.UI;
using UnityEngine;

public class InGameUIView : IWindow
{
    private readonly Canvas _canvas;
    private readonly InGameUIData _data;
    private readonly InGameUIModel _model;


    public InGameUIView(InGameUIModel model, Canvas canvas, InGameUIData data)
    {
        _model = model;
        _canvas = canvas;
        _data = data;
        _model.Opened += Open;
        _model.Closed += Close;
    }


    public void Dispose()
    {
        _model.Opened -= Open;
        _model.Closed -= Close;
    }

    public void UpdateView(OnScreenData screenData)
    {
        _data.HP.text = $"HP: {screenData.HP}";
        _data.Score.text = $"Score: {screenData.Score.CurrentScore}";
    }

    public void Close()
    {
        _model.ModelUpdated -= UpdateView;
        _canvas.enabled = false;
    }

    public void Open()
    {
        _model.ModelUpdated += UpdateView;
        _canvas.enabled = true;
    }
}