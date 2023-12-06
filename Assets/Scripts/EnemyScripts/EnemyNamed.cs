using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNamed : MonoBehaviour
{
    private EnemyNamedStatus enemyNamedStatus;
    private GameObject targetPlayer;
    private Vector3 targetPosition;
    private Vector3 dir;

    [SerializeField] private float speed;
    [SerializeField] private int hp;

    public EnemyNamedType enemyNamedType;

    private void Start()
    {
        enemyNamedStatus = new EnemyNamedStatus();
        enemyNamedStatus = enemyNamedStatus.SetStatus(enemyNamedType);
        targetPlayer = GameObject.FindWithTag("Player");
        speed = enemyNamedStatus._speed;
        hp = enemyNamedStatus._hp;
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
