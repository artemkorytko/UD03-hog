using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//подключенные библиотеки
public class UIGamePanel : MonoBehaviour //объявляем класс UIGamePanel, наследуем от MonoBehaviour. Скрипт вешается на панель с UI уровня
{
    [SerializeField] private RectTransform content; //объявляем приватную переменную content типа RectTransform
    [SerializeField] private UIitem prefab; //объявляем приватную переменную prefab типа UIitem
    //serialize field - значит будет выделено поле, можно инициилизировать из конструктора (передать ссылку)
    Dictionary<string, UIitem> items = new Dictionary<string, UIitem>(); //создаем словарь, ключем которого будет имя, а связанным с ним значением - UIitem, который храним картинку и значение кол-ва объектов

    public void Initialize(Level level) //метод для инициилизации словаря на новом уровне. Публичный, ничего не возвращает. НА вход получает уровень
    {
        foreach (var key in items.Keys) //перебираем текущий словарь для чистки
        {
            Destroy(items[key].gameObject); //удаляем все гейм объекта для каждого ключа
        }
        items.Clear(); //чистим словарь
        GenerateList(level.GetItemDictionary()); //запускаем метод для заполнения нового словаря для прохождения текущего уровня

        level.OnItemListChanged += OnItemsListChanged; //подписываем текущий уровень на ивент об изменениях кол-ва найденых итемов и, при сигнале, будем вызывать метод OnItemsListChanged
    }

    private void OnItemsListChanged(string name) //объявляем метод для реакции на ивент об изменении кол-ва найденых объектов. Приватный, ничего не возвращает. НА вход получает string имя
    {
        if (items.ContainsKey(name)) //если словарь содержит объект с таким именем
        {
            items[name].Decrease(); //то уменьшаем цифру в UI на 1
        }
    }

    private void GenerateList(Dictionary<string, GameItemData> itemsData) //метод для заполнения словаря
    {
        foreach (var key in itemsData.Keys) //перебираем словарь
        {
            UIitem item = Instantiate(prefab, content); //создаем объект (префаб - что создаем, контент - где создаем)
            item.SetSprite(itemsData[key].Sprite); //получаем спрайт
            item.SetCount(itemsData[key].Amount); //получаем кол-во
            items.Add(key, item); //заполняем поле в словаре
        }
        
    }
}
