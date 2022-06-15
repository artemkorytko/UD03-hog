using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGamePanel : MonoBehaviour
{
    [SerializeField] private RectTransform content;
    [SerializeField] private UIItem prefab;

    public void Initialaize(Level level)
    {

    }

    private void GenerateList()
    {
        UIItem item = Instantiate(prefab, content);
        item.SetSprite();
        item.SetCount();
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
