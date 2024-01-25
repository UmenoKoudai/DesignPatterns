using System;
using UniRx;
using UnityEngine;

public class ItemPresenter : MonoBehaviour
{
    [SerializeField]
    private ItemView _view;
    [SerializeField]
    private float _hitRange;

    private ItemModel _model;
    public event Action<ItemPresenter> OnDestroy;
    public IAbility Ability;

    public void Initialize(IAbility ability, Sprite sprite)
    {
        _view.Initialize(transform);
        _model = new ItemModel(transform.position.y);
        Ability = ability;
        GetComponent<SpriteRenderer>().sprite = sprite;
        Bind();
    }

    public void Bind()
    {
        _model.YProp.Subscribe(_view.SetY).AddTo(gameObject);
    }

    private void OnDisable()
    {
        OnDestroy?.Invoke(this);
    }

    public void ManualUpdate(float deltaTime)
    {
        _model.SetY(deltaTime);
        if(_model.IsHit(GameInfo.Instance.Player, this, _hitRange))
        {
            Ability.Use(GameInfo.Instance);
            Destroy(gameObject);
        }
        if(_model.MinYPoint()) Destroy(gameObject);
    }
}
