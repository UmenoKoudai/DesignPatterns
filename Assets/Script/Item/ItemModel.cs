using UniRx;
using UnityEngine;

public class ItemModel
{
    private readonly ReactiveProperty<float> _yProp;
    public IReactiveProperty<float> YProp => _yProp;
    public float Y => _yProp.Value;

    float _basePos;

    public ItemModel(float nowY)
    {
        _basePos = nowY;
        _yProp = new ReactiveProperty<float>(nowY);
    }

    public void Reset()
    {
        _yProp.Value = _basePos;
    }

    public void SetY(float direction)
    {
        _yProp.Value -= direction;
    }

    public bool IsHit(PlayerPresenter player, ItemPresenter item, float hitRange)
    {
        float distance = Vector3.Distance(player.transform.position, item.transform.position);
        if(distance < hitRange)
        {
            return true;
        }
        return false;
    }

    public bool MinYPoint()
    {
        return _yProp.Value <= -10;
    }
}
