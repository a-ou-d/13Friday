using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemies;
    public float spawnInterval = 2f;

    private GameObject enemy;
    private Vector2 spawnPos;
    private float randomX;
    private float randomY;

    private void Start()
    {
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    private void Update()
    {
        Vector2 right = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height * 0.5f));
        Vector2 left = -right;
        Vector2 top = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * 0.5f, Screen.height));
        Vector2 bottom = -left;

        randomX = Random.Range(right.x, left.x);
        randomY = Random.Range(top.y, bottom.y);
        spawnPos = new Vector2(randomX, randomY);
    }

    public GameObject SpawnObject()
    {
        if (enemies != null)
        {
            int random = Random.Range(0, enemies.Length);
            return Instantiate(enemies[random], spawnPos, Quaternion.identity);
        }
        return null;
    }
}