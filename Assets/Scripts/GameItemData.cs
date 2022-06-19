using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItemData
{
    public Sprite Sprite;//картинка обьекта
    public int Amount;// количество обьектов
   
    public GameItemData(Sprite sprite)//метод в котором присылаем спрайт
    {
        Sprite = sprite;//присвоение в конструкторе
        Amount = 1;//задаем количество
    }
   
    public void IncreaseAmount()//метод который добавляем или если нашли то уберает обьект
    {
        Amount++;//добавляем к текущему значению 1
    }

    public bool DecreaseAmount()//метод уменьшающий количество 
    {
        Amount--;//уменьшает значение на 1
        if (Amount <= 0)//проверка значения обьекта , если их стало <=0
        {
            return false;// то мы завершаем 
        }

        return true;//если обьекты остались то продолжаем играть 
    }
}
