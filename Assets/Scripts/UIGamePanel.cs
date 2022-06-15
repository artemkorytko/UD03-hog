using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGamePanel : MonoBehaviour
{
    [SerializeField] private RectTransform content;
    [SerializeField] private UIItem prefab;
    private Dictionary<string, UIItem> items = new Dictionary<string, UIItem>();

    public void Initialaize(Level level)
    {
        GenerateList(level.GetItemDictionary());
    }

    private void GenerateList(Dictionary<string, GameItemData> itemsData)
    {
        foreach (var key in itemsData.Keys)
        {
            UIItem item = Instantiate(prefab, content);
            item.SetSprite(itemsData[key].Sprite);
            item.SetCount(itemsData[key].Amount); 
            items.Add(key, item);
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
