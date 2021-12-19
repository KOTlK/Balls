using UnityEngine;

public class UI
{
    private readonly IWindow _pauseMenu;
    private readonly IWindow _inGameUI;

    public UI(Canvas pauseMenuCanvas, Canvas inGameUICanvas, OnScreenData screenData)
    {
        _pauseMenu = new PauseMenu(pauseMenuCanvas);
        _inGameUI = new InGameUI(inGameUICanvas, screenData);
    }

    public void Init()
    {
        _pauseMenu.Close();
        _inGameUI.Open();
    }

}
