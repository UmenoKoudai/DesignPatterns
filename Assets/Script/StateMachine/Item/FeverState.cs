using UnityEngine;

public class FeverState : IStateMachine
{
    ItemGenerator _generator;
    float _timer = 0f;
    float _feverTimer = 0f;
    float _defaultInterval;

    public FeverState(ItemGenerator generator)
    {
        _generator = generator;
    }

    public void Enter()
    {
        AudioManager.Instance.SEManager.SEPlay(AudioManager.SEState.Fever);
        _generator.FeverIcon.SetActive(true);
        _generator.NormalIcon.SetActive(false);
        _defaultInterval = _generator.Interval;
        _generator.Interval = 1f;
    }

    public void Exit()
    {
        _generator.FeverIcon.SetActive(false);
        _generator.NormalIcon.SetActive(true);
        _generator.Interval = _defaultInterval;
        _feverTimer = 0f;
    }

    public void Update()
    {
        _feverTimer += Time.deltaTime;
        if(_feverTimer > _generator.FeverInterval)
        {
            Exit();
            _generator.StateChange(ItemGenerator.GameMode.Normal);
        }
        _timer += Time.deltaTime;
        if (_timer > 0.5f)
        {
            _generator.CreateItem(5, ItemGenerator.CreateType.Coin);
            _generator.PreviousIndex.Clear();
            _timer = 0;
        }
    }
}
