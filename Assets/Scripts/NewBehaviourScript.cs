using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class NewBehaviourScript : MonoBehaviour //класс
{ //тело класс
    
    //глобальные переменные
    private NewClassForSum sumClass; //переменная
    private int x = 21;
    private int y = 10;
    private int y1 = 10;
    private int y2 = 10;
    private int y3 = 10;
    private int y4 = 10;
    private int result;

    private string text = "my text";
    private float xWithPoint = 1.5f;

    public void Setup() //метод
    {
        //тело метода
        sumClass = new NewClassForSum(); //экземпляр класс либо объект в системе
        result = sumClass.Sum(x, y); //вызов метода
        //int result = sumClass.Result;

        //result == 11;
        print(result);
    }

    public int /* возвращаемое значени */ SetupInt(int value) //метод с передаваемым значением
    {
        value += 10; //value == 11
        return value;
    }

    private void Logic()
    {
        print(result);
        //локальная переменная
        var valueInt = Random.Range(0, 10);
        var valueFloat = Random.Range(0f, 10f);
        var valueString = "text";

        int x = 1;
        x++; //x == 2
        x--; //x == 1
    }
}

[Serializable]
public class NewClassForSum //просто часть кода
{
    public int Result;
    private NewBehaviourScript newClass = new NewBehaviourScript();
    public int Sum(int value1, int value2)
    {
        Result = value1 + value2;
        return Result;
    }
}