using UnityEngine;

public class GoldenDooki : MonoBehaviour
{
    private ItemDrop itemDrop;
    private Transform playerTransform; // �÷��̾� ��ġ ����
    private float detectionRange = 15.0f; // �÷��̾� Ž�� ����
    private float fleeRange = 10.0f; // ����ġ�� ����
    private Vector2 originalPosition; // ���� �ʱ� ��ġ
    private float speed = 3.0f;

    private bool hasDroppedItem = false; // �������� �̹� ��ӵǾ����� ���θ� ��Ÿ���� �÷���

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // �÷��̾� ã��
        originalPosition = (Vector2)transform.position; // ������ �ʱ� ��ġ ����
        itemDrop = GetComponent<ItemDrop>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance((Vector2)transform.position, (Vector2)playerTransform.position);

        if (distanceToPlayer < detectionRange) // �÷��̾� Ž�� ���� ���� ���� ��
        {
            // �÷��̾���� ���� ���� ���ϱ�
            Vector2 directionToPlayer = ((Vector2)playerTransform.position - (Vector2)transform.position).normalized;

            // �÷��̾�κ��� ���� �Ÿ� �̻� �־������� �̵�
            if (distanceToPlayer < fleeRange) // ����ġ�� ���� ���� ���� ��
            {
                transform.position -= (Vector3)directionToPlayer * speed * Time.deltaTime;
            }
        }
        else
        {
            // �÷��̾ Ž�� ���� �ۿ� ������ �ʱ� ��ġ�� �̵�
            float distanceToOriginal = Vector2.Distance((Vector2)transform.position, originalPosition);
            if (distanceToOriginal > 0.1f) // ���� �Ÿ����� �ָ� �������� ��
            {
                // �ʱ� ��ġ�� �̵�
                Vector2 directionToOriginal = (originalPosition - (Vector2)transform.position).normalized;
                transform.position += (Vector3)directionToOriginal * speed * Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("��Ű����");
            Destroy(gameObject);
            OnDestroy();
        }
    }

    private void OnDestroy()
    {
        if (!hasDroppedItem)
        {
            itemDrop.DropRandomItem(); // �������� ���� ��ӵ��� �ʾҴٸ� ���� ������ ���
        }
    }
}
