using UnityEngine;

public class ClickSEPlay : MonoBehaviour
{
    public void ClickSE()
    {
        AudioManager.Instance.SEManager.SEPlay(AudioManager.SEState.Click);
    }
}
