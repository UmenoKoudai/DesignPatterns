using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemData", menuName = "ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField]
    List<Data> _itemDatas = new List<Data>();
    public List<Data> ItemDatas
    {
        get => _itemDatas;
        set => _itemDatas = value;
    }
}

[Serializable]
public class Data
{
    [SerializeField]
    [SubclassSelector]
    [SerializeReference]
    IAbility _ability;
    public IAbility Ability => _ability;

    [SerializeField]
    Sprite _itemImage;
    public Sprite ItemImage => _itemImage;

    [SerializeField]
    GameObject _itemPrefab;
    public GameObject ItemPrefab => _itemPrefab;
}
