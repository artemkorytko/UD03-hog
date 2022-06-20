using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//подключенные библиотеки
public class Level : MonoBehaviour //обявляем класс Level, наследуем от класса MonoBehaviour. Скрипт вешаем на префаб уровня
{
    private GameItem[] _gameItems; //объявляем приватный массив элементов типа GameItem с названием _gameItems
    private int _itemsCount; //объявляем приватную переменную типа int для значения кол-ва итемов

    public event Action OnComplete; //объявляем публичный ивент OnComplete для завершения уровня

    public event Action<string> OnItemListChanged; //объявляем публичный ивент OnItemListChanged, передающий значение типа string, для уведомления о изменении кол-ва итемов, которые мы нашли

    public void Initialize() //объявляем публичный метод Initialize для инициилизации итемов, которые будем искать
    {
        
        _gameItems = GetComponentsInChildren<GameItem>(); //заполняем массив типа GameItem всем дочерними объектами такого же типа

        for (int i = 0; i < _gameItems.Length; i++) //перебираем полученный массив
        {
            _gameItems[i].OnFind += OnFindItem; //подписываем каждый элемент массива на ивент OnFind и, при его сигнале, запустим метод OnFindItem
        }

        _itemsCount = _gameItems.Length; //заполняем переменную кол-вом итемов (длинна массива)
    }

    private void OnFindItem(string name) //объявляем метод, запускаемый после сигнала от ивента OnFind. Приватный, ничего не возвращает. На вход принимает string имя найденого объекта
    {
        _itemsCount--; //уменьшаем кол-во итемов на 1

        if(_itemsCount>0) //проверяем текущее кол-во искомых объектов
        {
            OnItemListChanged.Invoke(name); //если еще больше нуля, то запускаем ивент OnItemListChanged и передаем имя найденного объекта
        }
        else
        {
            OnComplete.Invoke(); //если дошли до нуля, то запускаем ивент для окончания уровня
        }
    }

    public Dictionary<string, GameItemData> GetItemDictionary() //объявляем публичный метод GetItemDictionary, который будет создавать словарь, заполнять его и по итогу вернет его
    {
        Dictionary<string, GameItemData> itemsData = new Dictionary<string, GameItemData>(); //создаем словарь, ключем которого будет имя объекта типа string, а приязанным к нему значением GameItemData (который в свою очередь хранит в себе информацию со спрайтом объекта и кол-вом этого объекта

        for (int i = 0; i < _gameItems.Length; i++) //перебираем массив итемов
        {
            string key = _gameItems[i].Name; //присваиваем string переменной (которая будет нашим ключем) имя объекта
            if (itemsData.ContainsKey(key)) //если такой объект уже есть в словаре 
            {
                itemsData[key].IncreaseAmount(); //то увеличиваем их кол-во на 1
            }
            else
            {
                itemsData.Add(key, new GameItemData(_gameItems[i].Sprite)); //если такого объекта еще нет в словаре, добавляем его в словарь
            }
        }

        return itemsData; //возвращаем словарь
    }
}
