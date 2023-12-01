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
    [SerializeField] private List<WeaponData> _weaponsDatas; // 무기의 데이터
    [SerializeField] private GameObject _weaponPrefab; // 무기의 프리팹

    private Controller _controller;

    [SerializeField] private Transform _weaponSpawnPoint; // 던질 무기가 생성 될 위치 입니다.

    private Vector2 _aimDirection = Vector2.zero; // 어떤 방향으로 던지는 벡터값 입니다.


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

        Debug.Log("발사");
        var newWeapon = Instantiate(_weaponPrefab, _weaponSpawnPoint.position, Quaternion.identity).GetComponent<Weapon>();
        newWeapon.weaponData = _weaponsDatas[(int)type];
        newWeapon.name = newWeapon.weaponData.WeaponName;
        newWeapon.GetComponent<SpriteRenderer>().sprite = newWeapon.weaponData.Icon;
        newWeapon.GetComponent<Rigidbody2D>().velocity = _aimDirection * Vector2.one * newWeapon.weaponData.MoveSpeed;
        return newWeapon;
    }
}
