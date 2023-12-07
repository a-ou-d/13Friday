using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class GoldenDooki : MonoBehaviour
{
    private ItemDrop itemDrop;
    private GameManager gameManager;
    private Transform playerTransform;
    private float detectionRange = 15.0f; // �÷��̾� Ž�� ����
    private float fleeRange = 10.0f; // ����ġ�� ����
    private Vector2 originalPosition; // ���� �ʱ� ��ġ
    private float speed = 3.0f;
    private int hp = 10;

    private bool hasDroppedItem = false;

    private void Start()
    {
        gameManager = GameManager.Instance;
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
            itemDrop.DropRandomItem(); // �������� ���� ��ӵ��� �ʾҴٸ� ���� ������ ���
        }
    }
}
