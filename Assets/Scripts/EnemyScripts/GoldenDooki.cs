using UnityEngine;

public class GoldenDooki : MonoBehaviour
{
    private Transform playerTransform; // 플레이어 위치 참조
    public float detectionRange = 5.0f; // 플레이어 탐지 범위
    private Vector3 originalPosition; // 몬스터 초기 위치
    private float speed = 3.0f;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // 플레이어 찾기
        originalPosition = transform.position; // 몬스터의 초기 위치 저장
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer < detectionRange) // 플레이어 탐지 범위 내에 있을 때
        {
            // 플레이어와의 방향 벡터 구하기
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;

            // 플레이어로부터 일정 거리 이상 멀어지도록 이동
            transform.position -= directionToPlayer * speed * Time.deltaTime;
        }
        else
        {
            // 탐지 범위를 벗어나면 초기 위치로 이동
            float distanceToOriginal = Vector3.Distance(transform.position, originalPosition);
            if (distanceToOriginal > 0.1f) // 일정 거리보다 멀리 떨어졌을 때
            {
                // 초기 위치로 이동
                Vector3 directionToOriginal = (originalPosition - transform.position).normalized;
                transform.position += directionToOriginal * speed * Time.deltaTime;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("두키잡음");
            Destroy(gameObject);

            // 여기에 아이템을 획득하는 등의 추가 동작을 구현하세요
        }
    }
}