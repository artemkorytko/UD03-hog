using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _countText;

    private int _count;

    public void SetSprite(Sprite sprite)
    {
        _image.sprite = sprite;
    }

    public void SetCount(int count)
    {
        _count = count;
        _countText.text = _count.ToString();
    }

    public void Decrease()
    {
        _count--;
        if (_count > 0)
        {
            _countText.text = _count.ToString();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
