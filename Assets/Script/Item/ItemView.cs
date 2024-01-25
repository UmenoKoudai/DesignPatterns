using UnityEngine;

public class ItemView : MonoBehaviour
{
    Transform _item;

    public void Initialize(Transform item)
    {
        _item = item;
    }

    public void SetY(float y)
    {
        _item.position = new Vector3(_item.position.x, y, 0);
    }
}
