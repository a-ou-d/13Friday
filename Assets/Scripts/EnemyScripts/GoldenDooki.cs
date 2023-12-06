using UnityEngine;

public class GoldenDooki : MonoBehaviour
{
    private ItemDrop itemDrop;
    private Transform playerTransform; // 플레이어 위치 참조
    private float detectionRange = 15.0f; // 플레이어 탐지 범위
    private float fleeRange = 10.0f; // 도망치는 범위
    private Vector2 originalPosition; // 몬스터 초기 위치
    private float speed = 3.0f;

    private bool hasDroppedItem = false; // 아이템이 이미 드롭되었는지 여부를 나타내는 플래그

    private void Start()
    {
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("두키잡음");
            Destroy(gameObject);
            OnDestroy();
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
