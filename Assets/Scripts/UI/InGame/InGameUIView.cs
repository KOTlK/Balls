using UnityEngine;

public class InGameUIView
{
    private readonly Canvas _canvas;
    private readonly InGameUIData _data;
    private readonly InGameUIModel _model;
    private readonly Localization _localization;
    private OnScreenData _screenData;


    public InGameUIView(InGameUIModel model, Canvas canvas, InGameUIData data, Localization local)
    {
        _model = model;
        _canvas = canvas;
        _data = data;
        _localization = local;
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
        _screenData = screenData;
        UpdateText();
    }

    private void UpdateText()
    {
        _data.HP.text = $"{_localization.FindString(_data.HP.name)}: {_screenData.HP.CurrentHp}";
        _data.Score.text = $"{_localization.FindString(_data.Score.name)}: {_screenData.Score.CurrentScore}";
    }

    public void Close()
    {
        _model.ModelUpdated -= UpdateView;
        _localization.LanguageChanged -= UpdateText;
        _canvas.enabled = false;
    }

    public void Open()
    {
        _model.ModelUpdated += UpdateView;
        _localization.LanguageChanged += UpdateText;
        _canvas.enabled = true;
    }
}