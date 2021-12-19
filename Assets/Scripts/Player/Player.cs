public class Player
{
    private readonly Score _score;
    private readonly Hp _hp;

    public Player(BallHandler ballHandler)
    {
        _score = new Score();
        _hp = new Hp();
        ballHandler.BallCatched += _score.Increase;
        ballHandler.BallFell += _hp.Decrese;
    }

    public Score Score => _score;
    public Hp Hp => _hp;

}
