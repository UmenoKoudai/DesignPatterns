using UniRx;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class InGamePresenter : MonoBehaviour
{
    [SerializeField]
    private PlayerPresenter _player = null;
    public PlayerPresenter Player => _player;

    [SerializeField]
    private BackGroundPresenter[] _backGround = null;

    [SerializeField]
    private ItemGenerator _itemGenerator = null;

    [SerializeField]
    ScorePresenter _score = null;
    public ScorePresenter Score => _score;

    [SerializeField]
    private FeverScorePresenter _feverScore = null;

    [SerializeField]
    private InGameView _view;

    [SerializeField]
    private float _gameSpeed = 0.005f;

    [SerializeField]
    private float _speedUpInterval = 1f;

    [SerializeField]
    private string _nextScene = "";


    private InGameModel _model;

    private void Awake()
    {
        _player.Init();
        _score.Init();
        _itemGenerator.Init();
        _feverScore.Init();
        _view.Init(_backGround);
        _model = new InGameModel(GameState.State.InGame, _gameSpeed, _speedUpInterval);
        _player.OnDead += _model.StateChange;
        Bind();
        InfoSet();
    }

    private void Bind()
    {
        _model.State.Subscribe(_view.SetState).AddTo(gameObject);
        _model.Speed.Subscribe(_view.SetSpeed).AddTo(gameObject);
    }

    void Update()
    {
        if (_model.State.Value == GameState.State.Dead) SceneController.Instance.LoadScene(_nextScene);
        if (_model.State.Value != GameState.State.InGame) return;
        _model.ManualUpdate();
        _view.ManualUpdate();
        _itemGenerator.ManualUpdate(_model.Speed.Value);
    }

    private void InfoSet()
    {
        GameInfo.Instance.Player = _player;
        GameInfo.Instance.Score = _score;
        GameInfo.Instance.Fever = _feverScore;
        GameInfo.Instance.Generator = _itemGenerator;
    }
}
