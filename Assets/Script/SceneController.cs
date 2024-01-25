using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    static SceneController _instance;
    public static SceneController Instance
    {
        get
        {
            if(_instance == null) _instance = FindObjectOfType<SceneController>();
            if (_instance == null) Debug.LogError("SceneController���A�^�b�`���ꂽ�I�u�W�F�N�g�����݂��܂���");
            return _instance;
        }
    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
