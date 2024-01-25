using UniRx;

public class ScoreModel
{
    private readonly ReactiveProperty<int> _score;
    public IReactiveProperty<int> Score => _score;

    public ScoreModel(int score)
    {
        _score = new ReactiveProperty<int>(score);
    }

    public void AddScore(int score)
    {
        _score.Value += score;
    }
}
