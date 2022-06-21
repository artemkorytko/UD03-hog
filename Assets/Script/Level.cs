using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Level : MonoBehaviour
{
    private GameItem[] _gameItems;// создаЄм массив наших объектов
    private int _itemsCount;// не знаю

    public event Action OnCompleted; // ивент вызываемый когда мы выполнили какое-то действие
    public event Action<string> OnItemListChanged; // без пон€ти€

    public void Initialize()// инициализаци€ объекта
    {
        _gameItems = GetComponentsInChildren<GameItem>();// находим компоненты в чилдрен

        for (int i = 0; i < _gameItems.Length; i++)//используем цикл дл€ нахождени€ компонентов в списке
        {
            _gameItems[i].OnFind += OnFindItem;//если находим нужный компонент в массиве, то говорим что нашли его
        }

        _itemsCount = _gameItems.Length;// без пон€ти€
    }

    private void OnFindItem(string name)//говорим что нашли объект по имени
    {
        _itemsCount--;//если нашли необходимый компонент, то вычитываем его

        if(_itemsCount > 0)//провер€ем услови€ нашли ли мы все компоненты
        {
            OnItemListChanged.Invoke(name);//если не нашли,то продолжаем искать остальные
        }
        else
        {
            OnCompleted.Invoke();//если нашли,то выполнено
        }
    }

    public Dictionary<string, GameItemData> GetItemDictionary()//создаЄм словарь наших объектов или компонентов наших объектов,е совсмсем понимаю
    {
        Dictionary<string, GameItemData> itemsData = new Dictionary<string, GameItemData>();//создаЄм экземпл€р словар€

        for (int i = 0; i < _gameItems.Length; i++)//запускаем цикл дл€ проверки нашли ли мы необходимый компонент
        {
            string key = _gameItems[i].Name;// не понимаю зачем мы эту строчку писали
            if (itemsData.ContainsKey(key))//делаем проверку если мы нашли в массиве айтемов необходимый наш компонент по имени
            {
                itemsData[key].IncreaseAmount();//не понимаю эту строчку
            }
            else
            {
                itemsData.Add(key, new GameItemData(_gameItems[i].Sprite));//не понимаю эту строчку
            }
        }
        return itemsData;//не понимаю
    }

}
