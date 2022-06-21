using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiItem : MonoBehaviour
{
    [SerializeField] private Image image;//присваиваем картинку в юнити
    [SerializeField] private TextMeshProUGUI countText;//присваиваем текст в юнити

    private int _count;// вызываем метод каунт в цифровом значении,но к чему не понимаю
    public void SetSprite(Sprite sprite)//устанавливаем спрайты к картинке или то как будет выглядеть картинка с нашим спрайтом
    {
        image.sprite = sprite;//не понимаю эту строчку
    }

    public void SetCount(int count)
    {
        _count = count;
        countText.text = _count.ToString();
    }

    public void Decrease()
    {
        _count--;
       if (_count > 0)
        {
            countText.text = _count.ToString();
        }
        else
        {
            gameObject.SetActive(false);
        }
       /*тут как я понимаю мы находим количество объектов на экране,если мы нашли все наши объекты,то игра заканчивается,если же нет,то продолжаем находить*/
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
