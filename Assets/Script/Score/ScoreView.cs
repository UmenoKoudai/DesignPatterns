using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    ScoreManager _scoreManager;
    Text _scoreText;
    int _agoScore = 0;
    public void Init(Text text, ScoreManager scoreManager)
    {
        _scoreText = text;
        _scoreManager = scoreManager;
    }

    public void ShowScore(int score)
    {
        _scoreManager.Score = score;
        _scoreText.DOCounter(_agoScore, score, 0.5f).OnComplete(() => { _scoreText.text = score.ToString(); _agoScore = score; });
    }
}
