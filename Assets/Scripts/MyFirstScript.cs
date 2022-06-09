using System;
using UnityEngine;

namespace MyNamespace
{
    public class MyFirstScript : MonoBehaviour
    {
        private int counter = 5;
        private int testCounter = 10;
        private bool isUseCondition;

        private void Start()
        {
            isUseCondition = 5 <= 5;
            
            if (isUseCondition)
            {
                CheckCondition(3);
                CheckCondition(5);
                CheckCondition(7);
            }
        }

        private void CheckCondition(int value)
        {
            if (value < 5)
            {
                Debug.Log("value less then 5");
            }
            else
            {
                Debug.Log("value greater then 5");
            }
            int temp = value == 7 ? 15 : 30;
            //Debug.Log(value == 7 ? "value equale then 7" : "value not equale then 7");
        }
    }
}