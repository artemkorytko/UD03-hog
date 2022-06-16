using System;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    public Sprite Sprite;
    private string Name;
    private SpriteRenderer _spriteRenderer;

    public event Action<string> OnFind;


    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Name = _spriteRenderer.sprite.name;
        Sprite = _spriteRenderer.sprite;
    }
    private void OnMauseUpAsButton()
    {
        Find();
    }

    private void Find()
    {
        Debug.Log(message: $"Find object{gameObject.name}");

        OnFind.Invoke(Name);
    }



}
