using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenDooki : MonoBehaviour
{
    private EnemyStatus enemyStatus;
    public string playerTag = "Player"; // 플레이어를 식별하기 위한 태그
    public float distanceThreshold = 3f; // 유지하고자 하는 거리


    private Transform playerTransform; // 플레이어의 Transform을 저장할 변수

    private void Start()
    {
        // 플레이어를 찾아서 저장
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player not found! Make sure the player has the correct tag.");
        }
    }

    private void Update()
    {
        // 플레이어가 없거나 몬스터가 비활성화되어 있다면 함수를 빠져나갑니다.
        if (playerTransform == null || !gameObject.activeSelf)
        {
            return;
        }

        // 몬스터와 플레이어 사이의 거리 계산
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // 플레이어와의 거리가 일정 거리 이상일 때만 몬스터를 이동시킵니다.
        if (distanceToPlayer > distanceThreshold)
        {
            // 플레이어를 향해 이동
            transform.LookAt(playerTransform);
            transform.position += transform.forward * enemyStatus._speed * Time.deltaTime;
        }
    }
}
