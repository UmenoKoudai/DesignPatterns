using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private float _invincibleTime;
    Transform _playerPosition;
    float _timer;

    //�����l��ݒ�(���̃v���C���[�̈ʒu)
    public void Initialize(Transform nowPosition, float invincibleTime)
    {
        _playerPosition = nowPosition;
        _invincibleTime = invincibleTime;
    }

    //X�̐��l���ς������v���C���[�̏ꏊ���X�V
    public void SetX(float x)
    {
        //Max�l��Min�l��ݒ�
        x = x > 2 ? 2 : x;
        x = x < -2 ? -2 : x;
        _playerPosition.position = new Vector3(x, _playerPosition.position.y, 0);
    }
}
