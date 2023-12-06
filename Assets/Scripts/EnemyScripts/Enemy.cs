using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyStatus enemyStatus;
    private GameObject targetPlayer;
    private Vector3 targetPosition;
    private Vector3 dir;

    [SerializeField] private float speed;
    [SerializeField] private int hp;

    public EnemyType enemyType;

    private void Start()
    {
        enemyStatus = new EnemyStatus();
        enemyStatus = enemyStatus.SetStatus(enemyType);
        targetPlayer = GameObject.FindWithTag("Player");
        speed = enemyStatus._speed;
        hp = enemyStatus._hp;
    }
    public void TakeDamage(int damage)
    {
        enemyStatus._hp -= damage;
    }

    private void Update()
    {
        targetPosition = targetPlayer.transform.position;
        dir = (targetPosition - transform.position).normalized;

        transform.position += dir * speed * Time.deltaTime;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

}