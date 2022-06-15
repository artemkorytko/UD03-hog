using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GameItem : MonoBehaviour
{
    private string Name;
    private SpriteRenderer _spriteRenderer;

    public event Action<string> OnFind;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Name = _spriteRenderer.sprite.name;

    }

    private void OnMouseUpAsButton()
    {
        Find();
    }

    private void Find()
    {
        Debug.Log($"Find object {gameObject.name}");
        OnFind.Invoke(Name);
    }

}
