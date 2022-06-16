using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGamePanel : MonoBehaviour
{
    [SerializeField] private RectTransform content;
    [SerializeField] private UIitem prefab;
    Dictionary<string, UIitem> items = new Dictionary<string, UIitem>();

    public void Initialize(Level level)
    {
        foreach (var key in items.Keys)
        {
            Destroy(items[key].gameObject);
        }
        items.Clear();
        GenerateList(level.GetItemDictionary());

        level.OnItemListChanged += OnItemsListChanged;
    }

    private void OnItemsListChanged(string name)
    {
        if (items.ContainsKey(name))
        {
            items[name].Decrease();
        }
    }

    private void GenerateList(Dictionary<string, GameItemData> itemsData)
    {
        foreach (var key in itemsData.Keys)
        {
            UIitem item = Instantiate(prefab, content);
            item.SetSprite(itemsData[key].Sprite);
            item.SetCount(itemsData[key].Amount);
            items.Add(key, item);
        }
        
    }
}
