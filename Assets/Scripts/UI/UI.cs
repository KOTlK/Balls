using UnityEngine;

public class UI
{
    private readonly IWindow _pauseMenu;
    private readonly IWindow _inGameUI;

    public IWindow InGameUI => _inGameUI; // for tests only

    public UI(Canvas pauseMenuCanvas, InGameUIInitialData inGameUIInitialData)
    {
        _pauseMenu = new PauseMenu(pauseMenuCanvas, inGameUIInitialData.GamePause);
        _inGameUI = new InGameUI(inGameUIInitialData);
    }

    public void Init()
    {
        _pauseMenu.Closed += _inGameUI.Open;
        _inGameUI.Closed += _pauseMenu.Open;
        _pauseMenu.Close();
    }

}
