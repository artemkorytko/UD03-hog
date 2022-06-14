using System.Collections.Generic;
using UnityEngine;

public class UIGamePanel : MonoBehaviour
{
    [SerializeField] private RectTransform _content;
    [SerializeField] private UIItem _prefab;

    private Dictionary<string, UIItem> itemsData = new Dictionary<string, UIItem>();


    public void Initialize(Level level)
    {
        GenerateList(level.GetItemDictionary());
    }

    private void GenerateList(Dictionary<string, GameItemData> itemsData)
    {
        foreach (var key in itemsData.Keys)
        {
            UIItem item = Instantiate(_prefab, _content);
            item.SetSprite(itemsData[key].Sprite);
            item.SetCount(itemsData[key].Amount);
            this.itemsData.Add(key, item);
        }
    }
}
