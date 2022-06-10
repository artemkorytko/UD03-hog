using System;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    private void OnMouseUpAsButton()
    {
        Find();
    }

    private void Find()
    {
        Debug.Log($"Find object {gameObject.name}");
    }
}
