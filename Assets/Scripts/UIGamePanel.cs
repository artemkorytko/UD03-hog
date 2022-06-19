using System.Collections.Generic;
using UnityEngine;

public class UIGamePanel : MonoBehaviour
{
    [SerializeField] private RectTransform _content;
    [SerializeField] private UIItem _prefab;

    private Dictionary<string, UIItem> _itemsData = new Dictionary<string, UIItem>();


    public void Initialize(Level level)
    {
        foreach (var key in _itemsData.Keys)
        {
            Destroy(_itemsData[key].gameObject);
        }
        _itemsData.Clear();
        
        GenerateList(level.GetItemDictionary());

        level.OnItemListChanged += OnItemListChanged;
    }

    private void OnItemListChanged(string name)
    {
        if (_itemsData.ContainsKey(name))
        {
            _itemsData[name].Decrease();
        }
    }

    private void GenerateList(Dictionary<string, GameItemData> itemsData)
    {
        foreach (var key in itemsData.Keys)
        {
            UIItem item = Instantiate(_prefab, _content);
            item.SetSprite(itemsData[key].Sprite);
            item.SetCount(itemsData[key].Amount);
            this._itemsData.Add(key, item);
        }
    }
}
