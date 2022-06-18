using System.Collections.Generic;//подключение библиотеки для использования словаря
using UnityEngine;//подключение библиотеки

public class UIGamePanel : MonoBehaviour//создание публичного класса игровой панели, наследуемого базового класса monobehaviour
{
    [SerializeField] private RectTransform content;//создание поля в пределах якорей,для добавления объектов в них, приватного типа,которая будет видна в инспекторе
    [SerializeField] private UIItem prefab;//создание префаба для добавления игровых объектов,приватного типа, который будет виден в инспекторе
    Dictionary<string, UIItem> items = new Dictionary<string, UIItem>();//инициализация словаря игровых объектов


    public void Initialize(Level level)//публичный метод для инициализации перебора ключей уровня
    {
        foreach (var key in items.Keys)//инициализация цикла перебора ключей
        {
            Destroy((items[key].gameObject));//уничтожает ключ игровой объект
        }
        items.Clear();//очищает объекты словаря
        GenerateList(level.GetItemDictionary());//вызов метода перебора ключей в словаре уровня

        level.OnItemListChanged += OnItemListChanged;//подписка на событие изменения объектов в листа  уровня
    }

    private void OnItemListChanged(string name)//приватный метод для измения ключей с определеным именем
    {
        if (items.ContainsKey(name))//условие,если объект содержит ключ с определенным именем,то
        {
            items[name].Decrease();//убираем объект с данным именем
        }
    }

    private void GenerateList(Dictionary<string, GameItemData> itemsData)//приватный метод для перебора ключей игровых объектов в словаре
    {
        foreach (var key in itemsData.Keys)//цикл перебора ключей игровых объектов
        {
            UIItem item = Instantiate(prefab, content);//инициализвация префаба с контентом в игровой панели
            item.SetSprite(itemsData[key].Sprite);//присвоение объекта к  ключю картинке
            item.SetCount(itemsData[key].Amount);//присвоение количества к ключю количества
            items.Add(key,item);//добавление объекту ключ объекта
        }
     
    }
}
