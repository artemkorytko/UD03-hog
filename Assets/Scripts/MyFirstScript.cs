using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    int counter = 5;
    int testCounter = 10;

    // Start is called before the first frame update
    void Start()
    {
        do
        {
            print("Hellow World");
            counter = counter + 1;
        } while (counter < testCounter);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
