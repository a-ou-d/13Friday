using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponJsonData
{
    public int type;
    public string name;
    public int damage;
    public float attackSpeed;
    public float speed;
    public string weaponPrefabAddress;
    public string weaponSpriteAddress;
}

public class WeaponDatas
{
    public List<WeaponJsonData> Datas;
}

public class WeaponData : MonoBehaviour
{


    public int type;
    public string name;
    public int damage;
    public float attackSpeed;
    public float speed;
    public Sprite weaponSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            enemy.TakeDamage(damage);
        }
    }
}

