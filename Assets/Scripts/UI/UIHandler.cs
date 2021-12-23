public class UIHandler
{
    private readonly UI _ui;
    private readonly GamePause _gamePause;
    private readonly Hp _hp;

    public UIHandler(UI ui, GamePause gamePause, Hp hp)
    {
        _ui = ui;
        _gamePause = gamePause;
        _hp = hp;
    }

    public void Init()
    {
        _ui.LoseScreen.Opened += _ui.PauseMenu.Close;
        _ui.LoseScreen.Opened += _ui.InGameUI.Close;

        _gamePause.GamePaused += _ui.PauseMenu.Open;
        _gamePause.GamePaused += _ui.InGameUI.Close;

        _gamePause.GameResume += _ui.PauseMenu.Close;
        _gamePause.GameResume += _ui.InGameUI.Open;

        _hp.HpOver += _ui.LoseScreen.Open;
        _hp.HpOver += _gamePause.Pause;
        _hp.HpOver += _ui.PauseMenu.Close;
        _hp.HpOver += _ui.InGameUI.Close;
        
    }
}

