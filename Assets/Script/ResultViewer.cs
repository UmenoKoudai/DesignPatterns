using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ResultViewer : MonoBehaviour
{
    [SerializeField]
    Text _resultText;

    void Start()
    {
        _resultText.DOCounter(0, ScoreManager.Instance.Score, 0.5f);
    }
}
