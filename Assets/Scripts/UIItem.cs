using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIItem : MonoBehaviour
{
    [SerializeField] private Image image;// ссылка на картинку
    [SerializeField] private TextMeshProUGUI countText;// ссылка на текст в картинке ,сколько обьектов

    private int _count;// переменная отвечающая за количество обьектов

    public void SetSprite(Sprite sprite)//метод устанавливающий спрайт
    {
        image.sprite = sprite;//нашей картинке присваивается спрайт который приходит
    }

    public void SetCount(int count)// метод передающий инфу сколько обьектов и показывающий текст(цифру) сколько этих обьектов
    
    {
        _count = count;//сохранит сколько обьектов изначально
        countText.text = _count.ToString();//переводим интовое значение в строку
    }

    public void Decrease()//метод который уменьшает кол-во обьектов когда мы их находим
    {
        _count--;// отнимаем 1 обьект
        if (_count > 0)//если после отнимания обьектов больше 0
        {
            countText.text = _count.ToString();//то мы пишем текст на 1 меньше
        }
        else// если значение <=0 то наш обьект выключается
        {
            gameObject.SetActive(false);//обращаемся к обьекту устанавливаем активность (true или false)
        }
    }
}
