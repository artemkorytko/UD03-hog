using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGamePanel : MonoBehaviour
{
    [SerializeField] private RectTransform content;//ссылка куда добавляется наша картинка что мы ищем
    [SerializeField] private UIItem prefab;//ссылка на наш игровой префаб
    Dictionary<string, UIItem> items = new Dictionary<string, UIItem>();//словарь который хранит экземпляры объектов

    public void Initialize(Level level)//метод который инициализирует игровую панель
    {
        foreach (var key in items.Keys)//проходимся по всем ключам
        {
            Destroy(items[key].gameObject);// дестроит все геймобджекты
        }
        items.Clear();// чистим дату
        
        GenerateList(level.GetItemDictionary());// создаем новый обьект

        level.OnItemListChanged += OnItemListChanged;// подписываемся на уровень
    }

    private void OnItemListChanged(string name)//метод
    {
        if (items.ContainsKey(name))//если айтем содержит ключ
        {
            items[name].Decrease();//то мы его убераем
        }
    }

    private void GenerateList(Dictionary<string, GameItemData> itemsData)//метод
    {
        foreach (var key in itemsData.Keys)//перебираем каждый ключ нашего словаря
        {
            UIItem item = Instantiate(prefab, content);//создаём объект
            item.SetSprite(itemsData[key].Sprite);// присваиваем итему спрайт
            item.SetCount(itemsData[key].Amount);// присваиваем итему количество
            items.Add(key, item);// даем итему ключ
        }
    }
}
