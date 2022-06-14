using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItenData 
{
    private Sprite _sprite;
    private int _amount;

    public GameItenData(Sprite sprite)
    {
        _sprite = sprite;
        _amount = 1;
    }

    public void IncreaseAmount()
    {
        _amount ++ ;
    }

    public bool DecreaseAmount()
    {
        _amount--;
        if( _amount <= 0)
        {
            return false;
        }
        return true;
    }

}
