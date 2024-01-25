using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAbility : IAbility
{
    [SerializeField]
    private int _score;
    public void Use(GameInfo info)
    {
        AudioManager.Instance.SEManager.SEPlay(AudioManager.SEState.Coin);
        info.Score.AddScore(_score);
    }
}
