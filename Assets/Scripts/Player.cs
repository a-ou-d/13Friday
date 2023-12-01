using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Controller
{
    GameObject Jason;
    GameObject Sadako;
    GameObject Pennywise;
    GameObject Saw;

    public void Awake()
    {
        Jason = new GameObject("Jason");
        Sadako = new GameObject("Sadako");
        Pennywise = new GameObject("Pennywise");
        Saw = new GameObject("Saw");
    }

    public void OnSkillEvent(InputValue value)
    {
        
        // �� ������Ʈ�� Ȱ��ȭ ���θ� ���� ��
        if ( Jason.activeSelf == true )
        {
            // ���� ��ũ��Ʈ���� �Ͻ������� ���ݷ� ���� �Լ�
            Debug.Log("Ư����ų���");
        }
        else if ( Sadako.activeSelf == true )
        {
            // PlayerController�� worldPos ���콺 Ŀ�� ��ġ�� �����̵�
        }
        else if (Pennywise.activeSelf == true )
        {
            // GameManager���� life +1 (�ִ� ��ġ ���� ��), ��� ���� ����
        }
        else if (Saw.activeSelf == true )
        {
            // ���� ��ũ��Ʈ���� �Ͻ������� ���� �ӵ� ���� �Լ�
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Enemy�� �浹���� ���� ó��
            PlayerTakeDamage();
        }
    }

    public void PlayerTakeDamage()
    {
        // GameManager�� Life -1 , DecreaseLifr �Լ� ��������
        GameManager.Instance.DecreaseLife(1);
    }
}
