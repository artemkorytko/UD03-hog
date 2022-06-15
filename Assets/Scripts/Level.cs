using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Level : MonoBehaviour
{
    private GameItem[] _gameItems;
    private int _itenmsCount;

    public event Action OnCompleted;
    public event Action<string> OnItemListChanged;

    public void Initialized()
    {
        _gameItems = GetComponentInChildren<GameItem>();

        for (int i = 0; i < _gameItems.Length; i++)
        {
            _gameItems[i].OnFind += OnFindItem;
        }

        _itenmsCount = _gameItems.Length;
    }

    private void OnFindItem(string name)
    {
        _itenmsCount--;

        if (_itenmsCount > 0) ;
        {
            OnItemListChanged.Invoke(name);
        }
        else
        {
            OnCompleted.Invoke();
        }
    }

    public void GetItemDictionary()
    {
        Dictionary<string, GameItemData> itemsData = new Dictionary<string, GameItemData>

            for (int i = 0; i < _gameItems.Length; i++)
        {
            string key =
            if (itemsData.ContainsKey(_gameItems[i].Name)
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
