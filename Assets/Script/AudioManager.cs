using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null) _instance = FindObjectOfType<AudioManager>();
            if (_instance == null) Debug.LogError("AudioManagerがアタッチされたオブジェクトが存在しません");
            return _instance;
        }
    }

    [SerializeField]
    private SE _se;
    public SE SEManager => _se;

    [SerializeField]
    private BGM _bgm;
    public BGM BGMManager => _bgm;

    [SerializeField]
    private BGMState _playBGM;

    public enum SEState
    {
        Coin,
        Star,
        Bomb,
        Fever,
        Click,
    }

    public enum BGMState
    {
        Title,
        InGame,
        Result,
    }

    private void Start()
    {
        _bgm.BGMPlay(_playBGM);
    }

    [Serializable]
    public class SE
    {
        [SerializeField]
        AudioSource _audio;
        [SerializeField]
        AudioClip[] _clip;

        public void SEPlay(SEState state)
        {
            int index = (int)state;
            _audio.PlayOneShot(_clip[index]);
        }
    }

    [Serializable]
    public class BGM
    {
        [SerializeField]
        AudioSource _audio;
        [SerializeField]
        AudioClip[] _clip;

        public void BGMPlay(BGMState state)
        {
            int index = (int)state;
            _audio.loop = true;
            _audio.clip = _clip[index];
            _audio.Play();
        }
    }

}
