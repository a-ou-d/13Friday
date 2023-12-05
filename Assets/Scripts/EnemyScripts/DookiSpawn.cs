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
        // 플레이어를 태그로 찾아서 player 변수에 할당
        player = GameObject.FindGameObjectWithTag(playerTag);

        if (player != null)
        {
            SpawnMonstersAroundPlayer();
        }
        else
        {
            Debug.LogError("플레이어를 찾을 수 없습니다!");
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





