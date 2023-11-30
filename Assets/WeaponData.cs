using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponData", menuName = "ScriptableObjects/WeaponData", order = 1)]

public class WeaponData : ScriptableObject
{
    public string seaponName;
    public int damage;
    public float attackSpeed;
    public float moveSpeed;
    public Sprite icon;
}
