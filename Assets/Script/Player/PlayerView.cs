using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private float _invincibleTime;
    Transform _playerPosition;
    float _timer;

    //初期値を設定(今のプレイヤーの位置)
    public void Initialize(Transform nowPosition, float invincibleTime)
    {
        _playerPosition = nowPosition;
        _invincibleTime = invincibleTime;
    }

    //Xの数値が変わったらプレイヤーの場所を更新
    public void SetX(float x)
    {
        //Max値とMin値を設定
        x = x > 2 ? 2 : x;
        x = x < -2 ? -2 : x;
        _playerPosition.position = new Vector3(x, _playerPosition.position.y, 0);
    }
}
