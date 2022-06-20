using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//подключенные библиотеки

public class GameItem : MonoBehaviour //объявление класса GameItem, наследуемый от класса MonoBehaviour. Скрипт вешается на префаб объекта, который будем искать на уровне
{
    public Sprite Sprite; //объявляем публичную переменную типa Sprite с именем Sprite
    public string Name; //объявляем публичную переменную типa string с именем Name
    private SpriteRenderer _spriteRenderer; //объявляем приватную переменную типa SpriteRenderer с именем _spriteRenderer

    public event Action<string> OnFind; //объявляем публичный ивент OnFind, который будет передать значение типа string в подписаные на него методы


    private void Awake() //метод из класса MonoBehaviour, срабатывает 1 раз при инициилизации объекта на сцене, раньше чем Start
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); //инициилизируем переменную через метод GetComponent, т.е. получаем SpriteRenderer текущего объекта
        Name = _spriteRenderer.sprite.name; //инициилизируем переменную, обращаясь к имени спрайта
        Sprite = _spriteRenderer.sprite; //инициилизируем переменную, обращаясь к спрайту
    }

    private void OnMouseUpAsButton() //метод из класса MonoBehaviour, срабатывает когда клик мыши находит коллайдер
    {
        Find(); //вызываем наш метод find
    }

    private void Find() //объявляем наш метод find, приватный, ничего не возвращает.
    {
        Debug.Log($"Find object {gameObject.name}"); //выводит имя найденного объекта в консоль
        OnFind.Invoke(Name); //запускает ивент OnFind и передает имя найденого объекта в подписаные на ивент методы
    }
}
