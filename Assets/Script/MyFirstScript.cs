using System.Collections;
using UnityEngine;

namespace Assets.Script
{
    public class MyFirstScript : MonoBehaviour
    {
        int counter = 5;
        int testCounter = 10;
        private bool isUseCondition;
        // Use this for initialization
        void Start()
        {
            isUseCondition = 5 < 5;
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
            else if (value == 5)
            {
                Debug.Log("value equal then 5");
            }
            else
            {
                Debug.Log("value greater then 5");
            }

            //Debug.Log(value == 7 ? "value equal then 7" : "value not equal then 7");
        }
        // Update is called once per frame
        void Update()
        {

        }
    }






}