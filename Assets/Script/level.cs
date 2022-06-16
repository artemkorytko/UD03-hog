using System;
using UnityEngine;

public class level : MonoBehaviour
{
    private GameItem[] _gameItems;
    private int _itemsCount;

    public event Action OnComplited;
    public event Action<string> OnItemListChanded;

    public void Initialize()
    {
        _gameItems = GetComponentsInChildren<GameItem>();
        for (int i = 0; i < _gameItems.Length; i++)
        {
            _gameItems[i].OnFind += OnFindItem;

        }
        _itemsCount = _gameItems.Length;
    }
    private void OnFindItem(string name)
    {
        _itemsCount--;
        if (_itemsCount > 0)
        {
            OnItemListChanged.Invoke(name);
        }
        else
        {
            OnComplited.Invoke();
        }
    }
    public Dictionary<string, GameItemData> GetItemDictionary()
    {
        Dictionary<string, GameItemData> itemsData = new Dictionary<string, GameItemData>();

        for (int i = 0; i < _gameItems.Length; i++)
        {
            string key = _gameItems[i].name;
            if (itemsData.ContainsKey(key))
            {
                itemsData[key].IncreaseAmount();
            }
            else
            {
                itemsData.Add(key, new GameItemData(_gameItems[i].Sprite));

            }
        }
        return itemsData; 
    }
}
