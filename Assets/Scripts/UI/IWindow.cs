using System;

public interface IWindow
{
    public event Action Opened;
    public event Action Closed;
    public void Open();
    public void Close();
}
