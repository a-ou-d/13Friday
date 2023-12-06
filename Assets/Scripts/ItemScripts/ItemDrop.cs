using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public ItemData[] possibleItems; // ��ӵ� ������ ���

    public void DropRandomItem()
    {
        if (possibleItems != null && possibleItems.Length > 0)
        {
            float totalProbability = 0f;

            foreach (ItemData item in possibleItems)
            {
                totalProbability += item.dropProbability; // ������ ��� Ȯ���� �ջ�
            }

            foreach (ItemData item in possibleItems)
            {
                float adjustedProbability = 100f - item.dropProbability; // �������� ��ӵ��� ���� Ȯ�� ���

                float randomChance = UnityEngine.Random.Range(0f, 100f); // 0���� 100 ������ ���� �� ����

                if (randomChance > adjustedProbability)
                {
                    Instantiate(item.itemPrefab, transform.position, Quaternion.identity);
                    break;
                }
            }
        }
    }
}

