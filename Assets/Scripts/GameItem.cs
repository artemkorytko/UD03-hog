using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameItem : MonoBehaviour
{
    public string Name;
    public Sprite Sprite;

    private SpriteRenderer _spriteRenderer;

    public event Action<string> onFind;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Name = _spriteRenderer.sprite.name;
        Sprite = _spriteRenderer.sprite;
    }

    private void OnMouseUpAsButton()
    {
        Find();
    }

    private void Find()
    {
        Debug.Log($"Find object{gameObject.name}");

        onFind.Invoke(Name);
    }

}
