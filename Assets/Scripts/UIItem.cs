using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIItem : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI countText;

    private int _count;

    public void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }

    public void SetCount(int count)
    {
        _count = count;
        countText.text = _count.ToString();
    }

    public void Decrease()
    {
        _count--;
        if(_count > 0)
        {
            countText.text = _count.ToString();
        }
        else
        {
            gameObject.SetActive(false);
        }
       
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
