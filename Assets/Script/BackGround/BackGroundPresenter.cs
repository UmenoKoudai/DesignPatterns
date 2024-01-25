using UniRx;
using UnityEngine;

public class BackGroundPresenter : MonoBehaviour
{
    [SerializeField]
    private BackGroundView _view;
    [SerializeField]
    private Transform _topTransform;
    [SerializeField]
    private Transform _bottomTransform;

    private BackGroundModel _model;

    public void Init()
    {
        _view.Init(transform);
        _model = new BackGroundModel(transform.position.y, _topTransform.position, _bottomTransform.position);
        Bind();
    }

    private void Bind()
    {
        _model.YProp.Subscribe(_view.SetY).AddTo(gameObject);
    }
    
    public void ManualUpdate(float deltaTime)
    {
        _model.SetY(deltaTime, transform);
    }
}
