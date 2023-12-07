using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] named;
    public GameObject[] boss;
    public float spawnInterval = 2f;
    public float namedSpawnInterval = 30f;
    public float bossSpawnInterval = 600f;

    private GameObject player;
    private Vector2 spawnPos;
    private float randomX;
    private float randomY;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
        InvokeRepeating("SpawnNamed", namedSpawnInterval, namedSpawnInterval);
        Invoke("SpawnBoss", bossSpawnInterval);
    }

    public void SpawnEnemy()
    {
        Vector2 right = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height * 0.5f));
        Vector2 left = -right;
        Vector2 top = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * 0.5f, Screen.height));
        Vector2 bottom = -left;

        if (enemies != null)
        {
            while (true)
            {
                randomX = Random.Range(right.x, left.x);
                randomY = Random.Range(top.y, bottom.y);

                if ((player.transform.position - new Vector3(randomX, randomY, 0f)).magnitude > 4f)
                {
                    spawnPos = new Vector2(randomX, randomY);                   
                }
                break;
            }

            int random = Random.Range(0, enemies.Length);
            Instantiate(enemies[random], spawnPos, Quaternion.identity);
        }
    }

    public void SpawnNamed()
    {
        if (named != null)
        {
            int random = Random.Range(0, named.Length);
            Instantiate(named[random], spawnPos, Quaternion.identity);
        }
    }

    public void SpawnBoss()
    {
        if (boss != null)
        {
            int random = Random.Range(0, boss.Length);
            Instantiate(boss[random], spawnPos, Quaternion.identity);
        }
    }
}