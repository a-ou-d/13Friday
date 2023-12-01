using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Machete,
    Saw,
    Balloon,
    CRTTV,

}

public class Shooting : MonoBehaviour
{
    [SerializeField] private List<WeaponData> _weaponsDatas; // ������ ������
    [SerializeField] private GameObject _weaponPrefab; // ������ ������

    private Controller _controller;

    [SerializeField] private Transform _weaponSpawnPoint; // ���� ���Ⱑ ���� �� ��ġ �Դϴ�.

    private Vector2 _aimDirection = Vector2.zero; // � �������� ������ ���Ͱ� �Դϴ�.


    private void Awake()
    {
        _controller = GetComponent<Controller>();
    }
    void Start()
    {
        _controller.OnAttackEvent += OnShoot;
        _controller.OnLookEvent += OnAim;
    }
    void Update()
    {

    }

    private void OnAim(Vector2 newAimDirection)
    {
        _aimDirection = newAimDirection;
    }
    private void OnShoot()
    {
        CreateProjectile(WeaponType.Saw);
        
    }

    private Weapon CreateProjectile(WeaponType type)
    {

        Debug.Log("�߻�");
        var newWeapon = Instantiate(_weaponPrefab, _weaponSpawnPoint.position, Quaternion.identity).GetComponent<Weapon>();
        newWeapon.weaponData = _weaponsDatas[(int)type];
        newWeapon.name = newWeapon.weaponData.WeaponName;
        newWeapon.GetComponent<SpriteRenderer>().sprite = newWeapon.weaponData.Icon;
        newWeapon.GetComponent<Rigidbody2D>().velocity = _aimDirection * Vector2.one * newWeapon.weaponData.MoveSpeed;
        return newWeapon;
    }
}
