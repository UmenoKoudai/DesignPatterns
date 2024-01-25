using UnityEngine;

public class InGameView : MonoBehaviour
{
    BackGroundPresenter[] _backGround;
    GameState.State _state;
    float _speed;

    public void Init(BackGroundPresenter[] backGround)
    {
        _backGround = backGround;
        foreach (var b in _backGround)
        {
            b.Init();
        }
    }

    public void ManualUpdate()
    {
        if (_state != GameState.State.InGame) return;
        foreach(var backGround in _backGround)
        {
            backGround.ManualUpdate(_speed);
        }
    }

    public void SetState(GameState.State changeState)
    {
        _state = changeState;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}
