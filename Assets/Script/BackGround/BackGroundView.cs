using UnityEngine;

public class BackGroundView : MonoBehaviour
{
    Transform _transform;

    public void Init(Transform transform)
    {
        _transform = transform;
    }

    public void SetY(float y)
    {
        _transform.position = new Vector3(_transform.position.x, y, 10);
    }
}
