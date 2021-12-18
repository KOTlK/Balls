using System;

public class InGameUIController
{
    private readonly InGameUIModel _model;
    private OnScreenData _screenData;
    public InGameUIController(InGameUIModel model)
    {
        _model = model;
    }


    public void UpdateUI(OnScreenData data)
    {
        _model.UpdateModel(data);
    }

    public void UpdateScore(Score score)
    {
        _screenData.Score = score;
        UpdateUI(_screenData);
    }


    public void Open() => _model.Open();
    public void Close() => _model.Close();
}
