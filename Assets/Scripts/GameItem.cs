using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
   
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>() ;
        
    }

    private void OnMouseUpAsButton()
    {
        Find();
    }

    private void Find()
    {
        Debug.Log($"Find oject{gameObject.name}");
    }
    void Update()
    {
        
    }
}
