public class Player
{
    private readonly Score _score;
    private readonly Hp _hp;
    private readonly HighScore _highScore;

    public Player(BallHandler ballHandler)
    {
        _score = new Score();
        _hp = new Hp();
        _highScore = new HighScore();
        ballHandler.BallCatched += _score.Increase;
        ballHandler.BallFell += _hp.Decrese;
        _hp.HpOver += SaveScore;
    }

    public Score Score => _score;
    public Hp Hp => _hp;

    private void SaveScore()
    {
        _highScore.TrySave(_score.CurrentScore);
    }

}
