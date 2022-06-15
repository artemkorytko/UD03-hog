using System.Collections;
using System.Collections.Generic;
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
        Debug.Log(message: $"Find object {gameObject.name}"); 
    }



}
