using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPresenter : MonoBehaviour
{
    [SerializeField]
    private float _invincibleTime = 2f;
    [SerializeField]
    PlayerView _view;
    PlayerModel _model;

    public event Action<GameState.State> OnDead;

    public void Init()
    {
        _view.Initialize(transform, _invincibleTime);
        _model = new PlayerModel(transform.position.x);
        Bind();
    }

    public void Bind()
    {
        _model.XProp.Subscribe(_view.SetX).AddTo(gameObject);
    }

    public void GameEnd()
    {
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        OnDead?.Invoke(GameState.State.Dead);

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var dir = context.ReadValue<Vector2>();
        _model.SetX((int)dir.x);
    }
}
