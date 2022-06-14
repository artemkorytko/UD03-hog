using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiPanel : MonoBehaviour
{
    [SerializeField] private RectTransform content;
    [SerializeField] private UIitem prefab;
    Dictionary<string, UIitem> itemsData = new Dictionary<string, UIitem>();    

    public void Initialize (Level level)
    {

    }

    private void GenerateList()
    {
        foreach (var key in itemsData.Keys)
        {
            UIitem item = Instantiate(prefab, content);
            item.SetSprite(itemsData[key].Sprite);
            item.SetCount(itemsData[key].Amount);
            itemsData.Add(key, item);
        }

    }

}
