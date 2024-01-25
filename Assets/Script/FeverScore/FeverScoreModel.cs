using UniRx;

public class FeverScoreModel
{
    private readonly ReactiveProperty<int> _feverScore;
    public IReactiveProperty<int> FeverScore => _feverScore;

    public FeverScoreModel(int initScore)
    {
        _feverScore = new ReactiveProperty<int>(initScore);
    }

    public void AddScore()
    {
        _feverScore.Value += 1;
        if (_feverScore.Value >= 5)
        {
            GameInfo.Instance.Generator.StateChange(ItemGenerator.GameMode.Fever);
            _feverScore.Value = 0;
        }
    }
}
