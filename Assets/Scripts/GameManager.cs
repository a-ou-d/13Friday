using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int life;

    private void Awake()
    {
        if (Instance == null)
        {
            
            
            life = 3;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DecreaseLife(int amount)
    {
        life -= amount;

        if (life <= 0)
        {
            //�������� 0���ϰ� ������ ���ӿ����� �θ���
            GameOver();
        }
    }

    private void GameOver()
    {
        // ���� ���� ���� ó��
        Debug.Log("Game Over");
    }
}
