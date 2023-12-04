using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenDooki : MonoBehaviour
{
    private EnemyStatus enemyStatus;
    public string playerTag = "Player"; // �÷��̾ �ĺ��ϱ� ���� �±�
    public float distanceThreshold = 3f; // �����ϰ��� �ϴ� �Ÿ�


    private Transform playerTransform; // �÷��̾��� Transform�� ������ ����

    private void Start()
    {
        // �÷��̾ ã�Ƽ� ����
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player not found! Make sure the player has the correct tag.");
        }
    }

    private void Update()
    {
        // �÷��̾ ���ų� ���Ͱ� ��Ȱ��ȭ�Ǿ� �ִٸ� �Լ��� ���������ϴ�.
        if (playerTransform == null || !gameObject.activeSelf)
        {
            return;
        }

        // ���Ϳ� �÷��̾� ������ �Ÿ� ���
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // �÷��̾���� �Ÿ��� ���� �Ÿ� �̻��� ���� ���͸� �̵���ŵ�ϴ�.
        if (distanceToPlayer > distanceThreshold)
        {
            // �÷��̾ ���� �̵�
            transform.LookAt(playerTransform);
            transform.position += transform.forward * enemyStatus._speed * Time.deltaTime;
        }
    }
}
