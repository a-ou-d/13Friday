using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DookiSpawn : MonoBehaviour
{
    public GameObject monsterPrefab; // 몬스터의 프리팹을 저장할 변수
    public float spawnRadius = 5f; // 몬스터가 생성될 반경

    public void SpawnMonsterNearPlayer()
    {
        // 플레이어의 위치를 가져옵니다.
        Vector3 playerPosition = transform.position;

        // 플레이어 주변에 몬스터를 생성하기 위해 랜덤한 위치를 계산합니다.
        Vector3 spawnPosition = playerPosition + Random.insideUnitSphere * spawnRadius;

        // 몬스터를 생성합니다.
        GameObject newMonster = Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);

        // 생성된 몬스터의 부모를 설정하거나 추가적인 초기화 등을 수행할 수 있습니다.
        // 예를 들어:
        // newMonster.transform.parent = transform; // 부모 설정

        // 생성된 몬스터에 대한 추가적인 설정을 할 수 있습니다.
        // newMonster.GetComponent<MonsterController>().player = playerTransform; // 플레이어 Transform 연결
    }
}
