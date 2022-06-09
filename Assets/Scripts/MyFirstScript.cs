using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    int counter = 5;
    int testCounter = 10;
    MyClass myClass;
    MyClass myClass1;


    // Start is called before the first frame update
    void Start()
    {
        //do
        //{
        //    print("Hellow World");
        //    counter = counter + 1;
        //} while (counter < testCounter);

        myClass = new MyClass();
        myClass1 = new MyClass();

    }


    // Update is called once per frame
    void Update()
    {
    }
}

public class MyClass
{
    int value;

    //public MyClass()
    //{
    //    Debug.Log(value);  
    //    value = 1;
    //    Debug.Log(value);
    //}

    //public MyClass(int customValue)
    //{
    //    Debug.Log(value);
    //    value = customValue;
    //    Debug.Log(value);
    //}
}