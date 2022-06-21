using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameItem : MonoBehaviour
{
    public Sprite Sprite; // �������� ������� � ����
    public string Name; // ��� ������� 
    private SpriteRenderer _spriteRenderer; // ��������� � ����

    public event Action<string> OnFind; // �����,������� ���������� ����� �� ����� ��� �������

    // Start is called before the first frame update
    private void Awake () //����� ������������ �� ������
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); // �������� ������ �� ��������� ������� ������������ � ����
        Name = _spriteRenderer.sprite.name; // �������� ������ �� ��� ����������
        Sprite = _spriteRenderer.sprite;//�������� ������ �� �������� ����������
    }
    private void OnMouseUpAsButton()//����� ������������ ��� ������� ������ ���� �� �������
    {
        Find();// ������ ������
    }
    private void Find()// ����� ������������ ����� �� ����� ������
    {
        Debug.Log($"Find object {gameObject.name}");//������� ���� �����������,��� �� ����� ������
        OnFind.Invoke(Name);// �������� ������� � ������� ��� �������
    }
    // Update is called once per frame
    void Update()
    {

    }
}
