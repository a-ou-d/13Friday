using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData itemdata;

    private string _name;
    private int _recover;
    private float _damages;
    private float _speed;
    private float _dropProbability;
    private Sprite _icon;
    public float lifespan = 30f;

    public void SetItemData()
    {
        _name = itemdata.name;
        _recover = itemdata.recover;
        _damages = itemdata.damages;
        _speed = itemdata.speed;
        _dropProbability = itemdata.dropProbability;

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
            Destroy(gameObject);
            ApplyItemEffects();
        }
    }
    private void ApplyItemEffects()
    {
        switch (itemdata.itemType)
        {
            case ItemData.ItemType.Recover:
                ApplyItemRecoverEffects();
                break;
            case ItemData.ItemType.Damage:
                ApplyItemDamageEffects();
                break;
            case ItemData.ItemType.Speed:
                ApplyItemSpeedEffects();
                break;
        }
    }

    private void ApplyItemSpeedEffects()
    {
        Debug.Log("스피드 업");
    }

    private void ApplyItemDamageEffects()
    {
        Debug.Log("다마게 업");
    }

    private void ApplyItemRecoverEffects()
    {
        Debug.Log("체력회복!");
    }
}
