using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DookiSpawn : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float minSpawnRadius = 5.0f;
    public float maxSpawnRadius = 10.0f;
    public int numberOfSurvivor = 1;
    public string playerTag = "Player";

    private GameObject player;

    private void Start()
    {
        // �÷��̾ �±׷� ã�Ƽ� player ������ �Ҵ�
        player = GameObject.FindGameObjectWithTag(playerTag);

        if (player != null)
        {
            SpawnMonstersAroundPlayer();
        }
        else
        {
            Debug.LogError("�÷��̾ ã�� �� �����ϴ�!");
        }
    }

    void SpawnMonstersAroundPlayer()
    {
        Vector3 playerPosition = player.transform.position;

        for (int i = 0; i < numberOfSurvivor; i++)
        {
            float randomSpawnRadius = Random.Range(minSpawnRadius, maxSpawnRadius);
            Vector2 randomSpawnOffset = Random.insideUnitCircle * randomSpawnRadius;
            Vector3 randomSpawnPosition = playerPosition + new Vector3(randomSpawnOffset.x, randomSpawnOffset.y, 0);
            Instantiate(EnemyPrefab, randomSpawnPosition, Quaternion.identity);
        }
    }
}





