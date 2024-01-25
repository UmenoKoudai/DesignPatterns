using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class FeverScorePresenter : MonoBehaviour
{

    [SerializeField]
    Image _feverGauge;
    [SerializeField]
    Sprite[] _feverImages;
    [SerializeField]
    FeverScoreView _view;
    FeverScoreModel _model;

    public void Init()
    {
        _view.Init(_feverGauge, _feverImages);
        _model = new FeverScoreModel(0);
        Bind();
    }

    void Bind()
    {
        _model.FeverScore.Subscribe(_view.GaugeView).AddTo(gameObject);
    }

    public void AddScore()
    {
        _model.AddScore();
    }
}
