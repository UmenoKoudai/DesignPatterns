using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _spawnPoint;
    [SerializeField]
    private ItemData _data;
    [SerializeField]
    private float _interval = 1f;
    public float Interval { get => _interval; set => _interval = value; }
    [SerializeField]
    private float _feverInterval;
    public float FeverInterval => _feverInterval;
    [SerializeField]
    private GameObject _feverIcon;
    public GameObject FeverIcon => _feverIcon;
    [SerializeField]
    private GameObject _normalIcon;
    public GameObject NormalIcon => _normalIcon;

    private List<ItemPresenter> _activeItem = new List<ItemPresenter>();
    private List<int> _previousIndex = new List<int>();
    public List<int> PreviousIndex { get => _previousIndex; set => _previousIndex = value; }
    private GameMode _mode;
    public GameMode Mode
    {
        get => _mode;
        set
        {
            if (_mode == value) return; //同じステートになった時にEnterを呼ばない仕組み
            _mode = value;
            switch(_mode)
            {
                case GameMode.Normal:
                    _normal.Enter();
                    break;
                case GameMode.Fever:
                    _fever.Enter(); 
                    break;
            }
        }
    }
    

    NormalState _normal;
    FeverState _fever;

    public enum GameMode
    {
        Normal,
        Fever,
    }

    public enum CreateType
    {
        Bomb,
        Star,
        Coin,
    }

    public void Init()
    {
        _normal = new NormalState(this, _activeItem);
        _fever = new FeverState(this);
    }

    public void ManualUpdate(float deltaTime)
    {
        switch (_mode)
        {
            case GameMode.Normal:
                _normal.Update();
                break;
            case GameMode.Fever:
                _fever.Update();
                break;
        }
        if (_activeItem.Count > 0)
        {
            foreach(var item in _activeItem)
            {
                item.ManualUpdate(deltaTime);
            }
        }
    }

    public void CreateItem(int createCount, CreateType type)
    {
        for (int i = 0; i < createCount; i++)
        {
            int randomItem = (int)type;
            int randomPos = Random.Range(0, _spawnPoint.Count);
            while (_previousIndex.Contains(randomPos))
            {
                randomPos = Random.Range(0, _spawnPoint.Count);
            }
            ItemPresenter item = Instantiate(_data.ItemDatas[randomItem].ItemPrefab, _spawnPoint[randomPos].position, Quaternion.identity).GetComponent<ItemPresenter>();
            item.Initialize(_data.ItemDatas[randomItem].Ability, _data.ItemDatas[randomItem].ItemImage);
            item.OnDestroy += ItemDestroy;
            _activeItem.Add(item);
            _previousIndex.Add(randomPos);
        }
    }

    public void ItemDestroy(ItemPresenter item)
    {
        _activeItem.Remove(item);
    }

    public void StateChange(GameMode changeMode)
    {
        Mode = changeMode;
    }
}
