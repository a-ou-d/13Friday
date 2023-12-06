using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DookiSpawn : MonoBehaviour
{
    public GameObject EnemyPrefab;
    private float minSpawnRadius = 10.0f;
    private float maxSpawnRadius = 15.0f;
    private string playerTag = "Player";
    private float spawnInterval = 3.0f;
    private float timer = 0.0f;
    private int maxNumOfSurvivor = 3;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
    }

    private void Update()
    {
        if (CountSurvivor() < maxNumOfSurvivor)
        {
            timer += Time.deltaTime;
        }
        

        if (timer >= spawnInterval && CountSurvivor() < maxNumOfSurvivor)
        {
            SpawnSurvivorNearPlayer();
            timer = 0.0f;
        }
    }

    int CountSurvivor()
    {
        GameObject[] survivor = GameObject.FindGameObjectsWithTag("Survivor");
        return survivor.Length;
    }

    void SpawnSurvivorNearPlayer()
    {
        if (player != null)
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized * Random.Range(minSpawnRadius, maxSpawnRadius);
            Vector2 spawnPosition = (Vector2)player.transform.position + randomDirection;

            Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.Log("플레이어를 찾을 수 없습니다.");
        }
    }
}
