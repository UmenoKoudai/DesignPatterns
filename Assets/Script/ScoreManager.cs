using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static ScoreManager _instance;
    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null) _instance = FindObjectOfType<ScoreManager>();
            if (_instance == null) Debug.LogError("SceneManagerをアタッチしたオブジェクトが存在しませ");
            return _instance;
        }
    }

    private int _score;
    public int Score { get => _score; set => _score = value; }

    private void Awake()
    {
        if(FindObjectsOfType<ScoreManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
