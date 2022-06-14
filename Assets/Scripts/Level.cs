using System;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private GameItem[] _gameItems;
    private int _itemsCount;

    public event Action OnCompleted;
    public event Action<string> OnItemListChanged;

    public void Initialize()
    {
        _gameItems = GetComponentsInChildren<GameItem>();

        for(int i = 0; i < _gameItems.Length; i++)
        {
            _gameItems[i].OnFind += OnFindItam;
        }

        _itemsCount = _gameItems.Length;
    }

    private void OnFindItam(string name)
    {
        _itemsCount--;
        if(_itemsCount > 0)
        {
            OnItemListChanged.Invoke(name);
        }
        else
        {
            OnCompleted.Invoke();
        }
    }

    public Dictionary<string, GameItemData> GetItemDictionary()
    {
        Dictionary<string, GameItemData> itemsData = new Dictionary<string, GameItemData>();

        for(int i = 0; i < _gameItems.Length; i++)
        {
            if (itemsData.ContainsKey(_gameItems[i].Name))
            {
                itemsData[_gameItems[i].Name].IncreaseAmount();
            }
            else
            {
                itemsData.Add(_gameItems[i].Name, new GameItemData(_gameItems[i].Sprite));
            }
            
        }

        return itemsData;
    }
}
