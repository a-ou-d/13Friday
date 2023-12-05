using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData weaponData;

    private string weaponName;
    private int weaponDamage;
    private float weaponAttackSpeed;
    private float weaponMoveSpeed;
    private Sprite icon;

    public void SetWeaponData()
    {
        weaponName = weaponData.name;
        weaponDamage = weaponData.Damage;
        weaponAttackSpeed = weaponData.AttackSpeed;
        weaponMoveSpeed = weaponData.MoveSpeed;
        icon = weaponData.Icon;
    }
}
