using UnityEngine;

public class GoldenDooki : MonoBehaviour
{
    private Transform playerTransform; // �÷��̾� ��ġ ����
    public float detectionRange = 5.0f; // �÷��̾� Ž�� ����
    private Vector3 originalPosition; // ���� �ʱ� ��ġ
    private float speed = 3.0f;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // �÷��̾� ã��
        originalPosition = transform.position; // ������ �ʱ� ��ġ ����
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer < detectionRange) // �÷��̾� Ž�� ���� ���� ���� ��
        {
            // �÷��̾���� ���� ���� ���ϱ�
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;

            // �÷��̾�κ��� ���� �Ÿ� �̻� �־������� �̵�
            transform.position -= directionToPlayer * speed * Time.deltaTime;
        }
        else
        {
            // Ž�� ������ ����� �ʱ� ��ġ�� �̵�
            float distanceToOriginal = Vector3.Distance(transform.position, originalPosition);
            if (distanceToOriginal > 0.1f) // ���� �Ÿ����� �ָ� �������� ��
            {
                // �ʱ� ��ġ�� �̵�
                Vector3 directionToOriginal = (originalPosition - transform.position).normalized;
                transform.position += directionToOriginal * speed * Time.deltaTime;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("��Ű����");
            Destroy(gameObject);

            // ���⿡ �������� ȹ���ϴ� ���� �߰� ������ �����ϼ���
        }
    }
}