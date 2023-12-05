using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Data", menuName = "ScriptableObjects/Weapon Data", order = 1)]

public class WeaponData : ScriptableObject
{
    [SerializeField]private string weaponName;
    public string WeaponName { get { return weaponName; } }

    [SerializeField]private int damage;
    public int Damage { get { return damage; } }    

    [SerializeField]private float attackSpeed;
    public float AttackSpeed { get { return attackSpeed; } }

    [SerializeField]private float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } }


    [SerializeField]private Sprite icon;
    public Sprite Icon { get { return icon; } }
}
