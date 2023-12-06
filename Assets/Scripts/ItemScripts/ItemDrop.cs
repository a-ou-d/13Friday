using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public ItemData[] possibleItems; // 드롭될 아이템 목록

    public void DropRandomItem()
    {
        if (possibleItems != null && possibleItems.Length > 0)
        {
            float totalProbability = 0f;

            foreach (ItemData item in possibleItems)
            {
                totalProbability += item.dropProbability; // 아이템 드롭 확률을 합산
            }

            foreach (ItemData item in possibleItems)
            {
                float adjustedProbability = 100f - item.dropProbability; // 아이템이 드롭되지 않을 확률 계산

                float randomChance = UnityEngine.Random.Range(0f, 100f); // 0부터 100 사이의 랜덤 값 생성

                if (randomChance > adjustedProbability)
                {
                    Instantiate(item.itemPrefab, transform.position, Quaternion.identity);
                    break;
                }
            }
        }
    }
}

