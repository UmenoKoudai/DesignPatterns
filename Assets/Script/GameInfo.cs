public class GameInfo
{
    static GameInfo _instance;
    public static GameInfo Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new GameInfo();
            }
            return _instance;
        }
    }
    private PlayerPresenter _player;
    public PlayerPresenter Player { get => _player; set => _player = value; }
    private ScorePresenter _score;
    public ScorePresenter Score { get => _score; set => _score = value; }
    private FeverScorePresenter _fever;
    public FeverScorePresenter Fever { get => _fever; set => _fever = value; }
    private ItemGenerator _generator;
    public ItemGenerator Generator { get => _generator; set => _generator = value; }
}
