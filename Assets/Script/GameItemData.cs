using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItemData
{
    public Sprite Sprite; // ссылка на картинку объекта
    public int Amount; //количество объектов со спрайтами
    public GameItemData(Sprite sprite) // не знаю что мы тут сделали
    {
        Sprite = sprite;// создаём экземпляр спрайта
        Amount = 1;//даём количеству цифровое значение
    }
    public void IncreaseAmount()// без понятия
    {
        Amount++;// без понятия
    }
    public bool DecreaseAmount()//без понятия
    {
        Amount--;//без понятия
        if(Amount <= 0)
        {
            return false;
        }
        return true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
