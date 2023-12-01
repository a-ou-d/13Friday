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

    public EnemyType enemyType;

    private void Start()
    {
        enemyStatus = new EnemyStatus();
        enemyStatus = enemyStatus.SetStatus(enemyType);
        targetPlayer = GameObject.FindWithTag("Player");
        speed = enemyStatus._speed;
    }

    private void Update()
    {
        targetPosition = targetPlayer.transform.position;
        dir = (targetPosition - transform.position).normalized;

        transform.position += dir * speed * Time.deltaTime;
    }
}