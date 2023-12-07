using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    private StageManager stageManager;
    private EnemyBossStatus enemyBossStatus;
    private GameObject targetPlayer;
    private Vector3 targetPosition;
    private Vector3 dir;


    [SerializeField] private float keepDistance;
    [SerializeField] private float speed;
    [SerializeField] private int hp;
    public bool isdie = false;

    float distance;

    public EnemyBossType enemyBossType;

    private void Start()
    {
        enemyBossStatus = new EnemyBossStatus();
        enemyBossStatus = enemyBossStatus.SetStatus(enemyBossType);
        targetPlayer = GameObject.FindWithTag("Player");
        speed = enemyBossStatus._speed;
        hp = enemyBossStatus._hp;
        keepDistance = enemyBossStatus._keepDistance;
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            GameManager.ObjectDestroyed();
            Destroy(gameObject);

            stageManager.ClearStage();
        }

    }

    private void Update()
    {
        targetPosition = targetPlayer.transform.position;
        distance = Vector3.Distance(targetPosition, transform.position);
        dir = (targetPosition - transform.position).normalized;

        if (keepDistance < distance)
        {
            transform.position += dir * speed * Time.deltaTime;
        }
    }
}