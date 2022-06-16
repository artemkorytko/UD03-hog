using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGamePanel : MonoBehaviour
{

    [SerializeField] private RectTransform _content;
    [SerializeField] private UIItem prefab;
    Dictionary<string, UIItem> items = new Dictionary<string, UIItem>();

    public void Initialize(Level level)
    {
        foreach (var key in items.Keys)
        {
            Destroy(items[key].gameObject);
        }

        items.Clear();

        _GenerateList(level.GetItemDictionary());

        level.OnItemListChanged += OnItemListChanged;
    }

    private void OnItemListChanged(string obj)
    {
        if (items.ContainsKey(name))
        {
            items[name].Decrease();
        }
    }

    private void _GenerateList(Dictionary<string, GameItemData> itemsData)
    {
        foreach (var key in itemsData.Keys)
        {
            UIItem item = Instantiate(prefab, _content);
            item.SetSprite(itemsData[key].Sprite);
            item.SetCount(itemsData[key].Amount);
            items.Add(key, item);
        }
        
    }
}
