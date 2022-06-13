using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnMauseUpAsButton()
    {
        Find();
    }

    private void Faind()
    {
        Debug.Log(message: $"Find object{gameObject.name}");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
