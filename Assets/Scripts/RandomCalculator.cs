using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCalculator : MonoBehaviour
{
    int value1, value2, value3;
    
 
    void start()
    {
        int value1 = Random.Range(0, 10);
        int value2 = Random.Range(0, 10);
        int value3 = Random.Range(0, 3);

    }
    public void CheckCondition()
    {
        if (value3 == 0)
        {
            Debug.Log(value1 + value2);
        }
        if (value3 == 1)
        {
            Debug.Log(value1*value2);
        }
        if (value3 == 2)
        {
            Debug.Log(value1 - value2);
        }
        if (value3 == 3)
        {
            Debug.Log(value1 / value2);
        }
    }
}
