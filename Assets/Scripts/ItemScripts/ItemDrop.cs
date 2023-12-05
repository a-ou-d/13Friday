using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public ItemData[] possibleItems; // ����� ������ ���
    private void DropRandomItem()
    {
        if (possibleItems.Length > 0)
        {
            float randomChance = UnityEngine.Random.value;

            foreach (ItemData item in possibleItems)
            {
                if (randomChance <= item.dropProbability)
                {
                    Instantiate(item.itemPrefab, transform.position, Quaternion.identity);
                    break;
                }
            }

        }
    }
}
