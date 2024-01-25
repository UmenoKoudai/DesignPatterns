using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class BackGroundModel
{
    private readonly ReactiveProperty<float> _yProp;
    public IReactiveProperty<float> YProp => _yProp;
    public float Y => _yProp.Value;

    Vector3 _top;
    Vector3 _bottom;
    float _baseY;

    public BackGroundModel(float y, Vector3 top, Vector3 bottom)
    {
        _yProp = new ReactiveProperty<float>(y);
        _baseY = y;
        _top = top;
        _bottom = bottom;
    }

    public void SetY(float y, Transform nowPosition)
    {
        _yProp.Value -= y;
        if (nowPosition.position.y >= _bottom.y) return;
        _yProp.Value = _top.y;
    }
}
