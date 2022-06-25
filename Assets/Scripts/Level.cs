using System.Collections.Generic;
using UnityEngine;
using System;

public class Level : MonoBehaviour
{
    private GameItem[] _gameItems;//переменная которая хранит наши обьекты
    private int _itemsCount;//переменная считающая кол-во обьектов

    public event Action OnCompleted; //вызывает событие что ур пройден
    public event Action<string> OnItemListChanged; //событие которые вызовется при нахождении объекта, то не в случае завершения уровня, когда нам требуется обновить список доступных для поиска объектов

    public void Initialize()//метод инициализирующий гейм мэнэджера
    {
        _gameItems = GetComponentsInChildren<GameItem>();//находит все обьекты в чаилдах в игре у кого есль компонент GAMEITEMS(SCRIPT)

        for (int i = 0; i < _gameItems.Length; i++)//цикл повторения
        {
            _gameItems[i].OnFind += OnFindItem;// тело цикла вызывает реакцию у левла что обьект нашелся
        }

        _itemsCount = _gameItems.Length;//говорит сколько айтемов тут есть 
    }

    private void OnFindItem(string name)// метод для левла что обьект нашелся
    {
        _itemsCount--;//когда обьект нашелся кол-во итемов уменьшится на 1 

        if (_itemsCount > 0)// если больше 0
        {
            OnItemListChanged.Invoke(name);// то говорит кого убрать 
        }
        else// если <=0
        {
            OnCompleted.Invoke();// игра заканчивается
        }
    }

    public Dictionary<string, GameItemData> GetItemDictionary()//массив отвечающий - сколько обьектов есть
    {
        Dictionary<string, GameItemData> itemsData = new Dictionary<string, GameItemData>();//словарь с ключем и информацией о уникальных обьектах на сцене

        for (int i = 0; i < _gameItems.Length; i++)//перебираем игровые обьекты
        {
            string key = _gameItems[i].Name;// локальная переменная нашему ключу
            if (itemsData.ContainsKey(key))// если содержит какой то ключь
            {
                itemsData[key].IncreaseAmount();//увеличиваем значение
            }
            else// сли нет такого ключа то мы его создаем
            {
                itemsData.Add(key, new GameItemData(_gameItems[i].Sprite));
            }
        }

        return itemsData;
    }
}
