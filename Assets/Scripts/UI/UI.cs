using UnityEngine;

public class UI
{
    private readonly IWindow _pauseMenu;
    private readonly IWindow _inGameUI;
    private readonly IWindow _loseScreen;

    public IWindow PauseMenu => _pauseMenu;
    public IWindow InGameUI => _inGameUI;
    public IWindow LoseScreen => _loseScreen;

    public UI(Canvas pauseMenuCanvas, InGameUIInitialData inGameUIInitialData, LoseScreenInitialData loseScreenData)
    {
        _pauseMenu = new PauseMenu(pauseMenuCanvas, inGameUIInitialData.GamePause);
        _inGameUI = new InGameUI(inGameUIInitialData);
        _loseScreen = new LoseScreen(loseScreenData);
    }

    public void Init()
    {
        _loseScreen.Close();
        _pauseMenu.Close();
        _inGameUI.Open();
    }

}
