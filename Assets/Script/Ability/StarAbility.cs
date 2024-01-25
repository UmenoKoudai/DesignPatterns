using System;
using UnityEngine;

public class StarAbility : IAbility
{
    public void Use(GameInfo info)
    {
        AudioManager.Instance.SEManager.SEPlay(AudioManager.SEState.Star);
        info.Fever.AddScore();
    }
}
