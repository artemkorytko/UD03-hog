using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameItem : MonoBehaviour
{
    public Sprite Sprite; // картинка объекта в игре
    public string Name; // имя объекта 
    private SpriteRenderer _spriteRenderer; // отрисовка в игре

    public event Action<string> OnFind; // ивент,который вызывается когда мы нашли имя объекта

    // Start is called before the first frame update
    private void Awake () //метод вызывающийся до старта
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); // получаем ссылку на компонент объекта находящегося в игре
        Name = _spriteRenderer.sprite.name; // получаем ссылку на имя компонента
        Sprite = _spriteRenderer.sprite;//получаем ссылку на картинку компонента
    }
    private void OnMouseUpAsButton()//метод вызывающийся при нажатии кнопки мыши на предмет
    {
        Find();// объект найден
    }
    private void Find()// метод вызывающийся когда мы нашли объект
    {
        Debug.Log($"Find object {gameObject.name}");//говорим всем компонентам,что мы нашли объект
        OnFind.Invoke(Name);// вызываем событие и передаём имя объекта
    }
    // Update is called once per frame
    void Update()
    {

    }
}
