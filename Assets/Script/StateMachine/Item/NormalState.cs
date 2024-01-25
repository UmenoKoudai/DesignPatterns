using System.Collections.Generic;
using UnityEngine;

public class NormalState : IStateMachine
{
    List<ItemPresenter> _activeItem = new List<ItemPresenter>();
    ItemGenerator _generator;
    float _timer = 0f;

    public NormalState(ItemGenerator generator, List<ItemPresenter> activeItem)
    {
        _generator = generator; 
        _activeItem = activeItem;
    }

    public void Enter()
    {
        //throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _generator.Interval)
        {
            int coinCount = Random.Range(0, 3);
            _generator.CreateItem(1, ItemGenerator.CreateType.Bomb);
            _generator.CreateItem(coinCount, ItemGenerator.CreateType.Coin);
            _generator.CreateItem(2 - coinCount, ItemGenerator.CreateType.Star);
            _generator.PreviousIndex.Clear();
            _timer = 0;
        }
    }
}
