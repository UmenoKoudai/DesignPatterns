using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ScorePresenter : MonoBehaviour
{
    [SerializeField]
    Text _scoreText;
    [SerializeField]
    ScoreView _view;
    ScoreModel _model;

    public void Init()
    {
        _view.Init(_scoreText, ScoreManager.Instance);
        _model = new ScoreModel(0);
        Bind();
    }

    private void Bind()
    {
        _model.Score.Subscribe(_view.ShowScore).AddTo(gameObject);
    }

    public void AddScore(int score)
    {
        _model.AddScore(score);
    }
}
