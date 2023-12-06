using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData itemdata;
    private GameManager gameManager;
    private Shooting shooting;

    private string _name;
    private int _recover;
    private float _damages;
    private float _speed;
    private float _dropProbability;
    private Sprite _icon;
    public float lifespan = 30f;
    private float SpeedDuration = 5f;
    private float DamageDuration = 5f;
    public bool isSpeed;
    public bool isDamage;

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
        SetItemData();

        gameManager = GameManager.Instance;

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
        Debug.Log("���ǵ� ��");
    }

    private void ApplyItemDamageEffects()
    {
        Debug.Log("���� ������ ��ȭ!");
    }

    private void ApplyItemRecoverEffects()
    {
        if (gameManager != null)
        {
            gameManager.Heal(_recover);
        }
        Debug.Log("ü��ȸ��!");
    }

}
