using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData itemdata;

    private string Name;
    private int Recover;
    private float Damages;
    private float Speed;
    private float DropProbability;
    private Sprite Icon;
    public float lifespan = 30f;

    public void SetItemData()
    {
        Name = itemdata.name;
        Recover = itemdata.recover;
        Damages = itemdata.damages;
        Speed = itemdata.speed;
        DropProbability = itemdata.dropProbability;

    }
    private void Start()
    {
        Invoke("DestroyItem", lifespan);
    }
    private void DestroyItem()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("아이템 획득");
            Destroy(gameObject);

            // 여기에 아이템을 획득하는 등의 추가 동작을 구현하세요
        }
    }
}
