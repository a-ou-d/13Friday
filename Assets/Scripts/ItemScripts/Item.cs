using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData itemdata;

    private string name;
    private int recover;
    private float damages;
    private float speed;
    private float dropProbability;
    private Sprite icon;
    public float lifespan = 30f;

    public void SetItemData()
    {
        name = itemdata.name;
        recover = itemdata.recover;
        damages = itemdata.damages;
        speed = itemdata.speed;
        dropProbability = itemdata.dropProbability;

    }
    private void Start()
    {
        Invoke("DestroyItem", lifespan);
    }
    private void DestroyItem()
    {
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DestroyItem();
        }
    }
}
