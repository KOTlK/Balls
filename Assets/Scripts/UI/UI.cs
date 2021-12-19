using System.Collections;
using UnityEngine;

public class UI
{
    private readonly PauseMenu _pauseMenu;
    private readonly InGameUI _inGameUI;

    public UI(Canvas pauseMenuCanvas, Canvas inGameUICanvas, OnScreenData screenData)
    {
        _pauseMenu = new PauseMenu(pauseMenuCanvas);
        _inGameUI = new InGameUI(inGameUICanvas, inGameUICanvas.GetComponent<InGameUIData>(), screenData);
    }

    public void Init()
    {
        _pauseMenu.Close();
        _inGameUI.Controller.Open();
    }

}


public struct OnScreenData
{
    public Score Score;
    public Hp HP;
}