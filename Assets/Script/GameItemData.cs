using UnityEngine;

public class GameItemData
{
    private Sprite _sprite;
    private Sprite _amount;

    public GameItemData(Sprite sprite)
    {
        _sprite = sprite;
        _amount = 1;
    }
    public void IncreAmaunt()
    {
        _amaunt++;
    }
    
    public bool DecreaseAmount()
    {
        _amount--;
        if (_amaunt <= 0)
        {
            return false;
        }
        {
            return true;
        }

    }
} 
