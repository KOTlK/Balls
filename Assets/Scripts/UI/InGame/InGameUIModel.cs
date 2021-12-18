using System;

public class InGameUIModel
{
    public event Action<OnScreenData> ModelUpdated;
    public event Action Opened;
    public event Action Closed;

    public void UpdateModel(OnScreenData data)
    {
        ModelUpdated?.Invoke(data);
    }

    public void Open()
    {
        Opened?.Invoke();
    }

    public void Close()
    {
        Closed?.Invoke();
    }

}
