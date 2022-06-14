using System.Collections.Generic;
using UnityEngine;

public class UiGamePanel : MonoBehaviour
{
    [SerializeField] private RectTransform content;
    [SerializeField] private UIItem prefab;
    Dictionary<string, UIItem> items = new Dictionary<string, UIItem>();

    public void Initialize(Level level)
    {
        GenerateList(level.GetItemDictionary());
    }

    private void GenerateList(Dictionary<string, GameItemData> itemsData)
    {
        foreach (var key in itemsData.Keys)
        {
            UIItem item = Instantiate(prefab, content);
            item.SetSprite(itemsData[key].Sprite);
            item.SetCount(itemsData[key].Amount);
            items.Add(key, item);
        }
    }
}