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

    public void IncreaseAmount()
    {
        _amount++;
    }

    public bool DecreaseAmount()
    {
        _amount--;

        return _amount > 0;
    }
}
