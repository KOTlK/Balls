﻿public class InGameUIController
{
    private readonly InGameUIModel _model;
    private OnScreenData _screenData;
    public InGameUIController(InGameUIModel model, OnScreenData screenData)
    {
        _screenData = screenData;
        _model = model;
    }


    public void UpdateUI()
    {
        _model.UpdateModel(_screenData);
    }



    public void Open()
    {
        UpdateUI();
        _model.Open();
    }
    public void Close() => _model.Close();
}
