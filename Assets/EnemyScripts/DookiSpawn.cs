using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DookiSpawn : MonoBehaviour
{
    public GameObject EnemyPrefab; // ������ �������� ������ ����
    public float spawnRadius = 5f; // ���Ͱ� ������ �ݰ�

    public void SpawnEnemyNearPlayer()
    {
        // �÷��̾��� ��ġ�� �����ɴϴ�.
        Vector3 playerPosition = transform.position;

        // �÷��̾� �ֺ��� ���͸� �����ϱ� ���� ������ ��ġ�� ����մϴ�.
        Vector3 spawnPosition = playerPosition + Random.insideUnitSphere * spawnRadius;

        // ���͸� �����մϴ�.
        GameObject newMonster = Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);

        // ������ ������ �θ� �����ϰų� �߰����� �ʱ�ȭ ���� ������ �� �ֽ��ϴ�.
        // ���� ���:
        // newMonster.transform.parent = transform; // �θ� ����

        // ������ ���Ϳ� ���� �߰����� ������ �� �� �ֽ��ϴ�.
        // newMonster.GetComponent<MonsterController>().player = playerTransform; // �÷��̾� Transform ����
    }

}