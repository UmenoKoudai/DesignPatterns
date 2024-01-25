using UnityEngine;
using UnityEngine.UI;

public class FeverScoreView : MonoBehaviour
{
    Sprite[] _feverImage;
    Image _feverGauge;

    public void Init(Image feverGauge, Sprite[] feverImage)
    {
        _feverGauge = feverGauge;
        _feverImage = feverImage;
    }

    public void GaugeView(int nowScore)
    {
        _feverGauge.sprite = _feverImage[nowScore];
    }
}
