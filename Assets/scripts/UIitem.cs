using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//подключенные библиотеки
public class UIitem : MonoBehaviour //объявляем класс UIitem и наследуем от MonoBehaviour. Скрипт вешаем на префаб UIitem, который имеет меняющуюся картинку и каунтер (значение кол-ва)
{
    [SerializeField] private Image image; //объявляем приватную переменную image типа Image
    [SerializeField] private TextMeshProUGUI countText; //объявляем приватную переменную countText типа TextMeshProUGUI
    //serialize field - значит будет выделено поле, можно инициилизировать из конструктора (передать ссылку)

    private int _count; //объявляем приватную переменную _count типа int

    public void SetSprite(Sprite sprite) //объявляем публичный метод для передачи спрайта в словарь. Ничего не возвращает, на вход получает спрайт
    {
        image.sprite = sprite; //записываем в переменную image спрайт, полученный на входе
    }

    public void SetCount(int count) //объявляем публичный метод для передачи кол-ва объектов в словарь. Ничего не возвращает, на вход получает кол-во типа int
    {
        _count = count; //записываем в переменную _count кол-во объектов, полученное на входе
        countText.text = _count.ToString(); //переводим int значение в string и записывает в countText в свойство text
    }

    public void Decrease() //объявляем публичный метод для уменьшения каунтера UI. Ничего не возвращает
    {
        _count--; //уменьшаем каунтер на 1
        if (_count > 0) //проверяем
        {
            countText.text = _count.ToString(); //если в каунтере значение все еще больше нуля, то перезаписываем в countText в свойство text (переводя из int в string)
        }
        else
        {
            gameObject.SetActive(false); //если достигли нуля, то отключает гейм объект 
        }
    }
}
