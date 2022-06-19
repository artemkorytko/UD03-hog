using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GameItem : MonoBehaviour
{
    public Sprite Sprite; //картинка обьекта 
    public string Name; //имя обьекта
    private SpriteRenderer _spriteRenderer; //компонент отвечающий за отрисовку обьекта в 2д игре 
    public event Action<string> OnFind; //событие экшн отвечающий за то что мы нашли обьект и передает имя обьекта 

    private void Awake() // такой же метод как и START только включается раньше всех существующих методов
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();//ссылка на компонент на нашем обьекте
        Name = _spriteRenderer.sprite.name;//присваиваем имя нашей картинке
        Sprite = _spriteRenderer.sprite;//ссылка от куда брать картинку
    }

    private void OnMouseUpAsButton() //метод вызовется когда мы кликнем по обьекту у которого есть колайдер
    {
        Find(); // мы нашли обьект
    }

    private void Find() //метод говорить что делается когда нашли обьект
    {
        Debug.Log($"Find object {gameObject.name}"); // расказываем системе что мы нашли 
        OnFind.Invoke(Name); //вызываем событие и передаем имя обьекта
    }

}
