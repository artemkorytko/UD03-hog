using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//подлюченные библиотеки
public class GameItemData //объявляем класс GameItemData, не наследуем от MonoBehaviour, т.к. будем внутри объявлять конструктор
{
    public Sprite Sprite; //объявляем переменную типа Sprite с именем Sprite
    public int Amount; //объявляем переменную типа int с именем Amount

    public GameItemData(Sprite sprite) //объявляем конструктор с именем класса, на вход получаем переменную типа Sprite с локальным именем sprite
    {
        Sprite = sprite; //инициилизируем переменную спрайтом, пришедшим в метод
        Amount = 1; //инициилизируем int переменную. Равна 1
    }

    public void IncreaseAmount() //объявляем наш метод IncreaseAmount, публичный, ничего не возвращает
    {
        Amount++; //увеличиваем значение нашей int переменной на 1
    }

    public bool DecreaseAmount() //объявляем наш метод DecreaseAmount, публичный, возвращает логическое значение true/false. 
    {
        Amount--; //уменьшаем значение нашей int переменной на 1
        if(Amount <= 0) //проверка на значение <=0
        {
            return false; //если значение 0 или меньше, метод возвращает false
        }

        return true; //иначе метод вернет true
    }
}
