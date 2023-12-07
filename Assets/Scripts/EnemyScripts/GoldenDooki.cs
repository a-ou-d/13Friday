using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class GoldenDooki : MonoBehaviour
{
    private ItemDrop itemDrop;
    private GameManager gameManager;
    private Transform playerTransform;
    private float detectionRange = 15.0f; // 플레이어 탐지 범위
    private float fleeRange = 10.0f; // 도망치는 범위
    private Vector2 originalPosition; // 몬스터 초기 위치
    private float speed = 3.0f;
    private int hp = 10;

    private bool hasDroppedItem = false;

    private void Start()
    {
        gameManager = GameManager.Instance;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // 플레이어 찾기
        originalPosition = (Vector2)transform.position; // 몬스터의 초기 위치 저장
        itemDrop = GetComponent<ItemDrop>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance((Vector2)transform.position, (Vector2)playerTransform.position);

        if (distanceToPlayer < detectionRange) // 플레이어 탐지 범위 내에 있을 때
        {
            // 플레이어와의 방향 벡터 구하기
            Vector2 directionToPlayer = ((Vector2)playerTransform.position - (Vector2)transform.position).normalized;

            // 플레이어로부터 일정 거리 이상 멀어지도록 이동
            if (distanceToPlayer < fleeRange) // 도망치는 범위 내에 있을 때
            {
                transform.position -= (Vector3)directionToPlayer * speed * Time.deltaTime;
            }
        }
        else
        {
            // 플레이어가 탐지 범위 밖에 있으면 초기 위치로 이동
            float distanceToOriginal = Vector2.Distance((Vector2)transform.position, originalPosition);
            if (distanceToOriginal > 0.1f) // 일정 거리보다 멀리 떨어졌을 때
            {
                // 초기 위치로 이동
                Vector2 directionToOriginal = (originalPosition - (Vector2)transform.position).normalized;
                transform.position += (Vector3)directionToOriginal * speed * Time.deltaTime;
            }
        }
        IsDead();
    }
    public void TakeDamage(int damage)
    {
        hp -= damage + gameManager.IncreaseDamage;
    }
    private void IsDead()
    {
        if (hp <= 0)
        {
            GameManager.ObjectDestroyed();
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (!hasDroppedItem)
        {
            itemDrop.DropRandomItem(); // 아이템이 아직 드롭되지 않았다면 랜덤 아이템 드롭
        }
    }
}
