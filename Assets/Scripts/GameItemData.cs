using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItemData 
{
    private Sprite _sprite;
    private int _amount;

    public GameItemData(Sprite sprite)
    {
        _sprite = sprite;
        _amount = 1;
    }

    public bool DecreaseAmount()
    {
        _amount--;
        if (_amount <= 0)
        {
            return false;
        }

        return true;
    }

    public void IncreaseAmount()
    {
        _amount++;
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
