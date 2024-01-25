using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class InGameModel : MonoBehaviour
{
    private readonly ReactiveProperty<GameState.State> _state;
    public IReactiveProperty<GameState.State> State => _state;

    private readonly ReactiveProperty<float> _speed;
    public IReactiveProperty<float> Speed => _speed;

    private float _interval;

    private float _timer;

    public InGameModel(GameState.State state, float initSpeed, float interval)
    {
        _state = new ReactiveProperty<GameState.State>(state);
        _speed = new ReactiveProperty<float>(initSpeed);
        _interval = interval;
    }

    public void StateChange(GameState.State changeState)
    {
        _state.Value = changeState;
    }

    public void ManualUpdate()
    {
        _timer += Time.deltaTime;
        if(_timer > _interval)
        {
            Debug.Log($"Speed:{_speed.Value}");
            _speed.Value += _speed.Value + 0.001f <= 0.1f ? 0.001f : 0f;
            _timer = 0;
        }
    }
}
