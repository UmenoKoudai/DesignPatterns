using UniRx;

public class PlayerModel
{
    private readonly ReactiveProperty<float> _xProp;
    public IReactiveProperty<float> XProp => _xProp;
    public float X => _xProp.Value;

    float _baseX;

    public PlayerModel(float nowX)
    {
        _baseX = nowX;
        _xProp = new ReactiveProperty<float>(nowX);
    }

    public void Reset()
    {
        _xProp.Value = _baseX;
    }

    public void SetX(int direction)
    {
        _xProp.Value += direction * 0.5f;
    }
}
