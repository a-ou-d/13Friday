using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform _weaponSpawnPoint; // 던질 무기가 생성 될 위치 입니다.
    private Vector2 _aimDirection = Vector2.zero; // 어떤 방향으로 던지는 벡터값 입니다.
    private Controller _controller;
    private WeaponLoader _weaponLoader;

    private SpriteRenderer _weaponSprite;

    private GameObject weaponPrefab;

    private Vector2 playerSpeed;

    public void SetPlayerSpeed(Vector2 speed)
    {
        playerSpeed = speed;
    }

    private void Awake()
    {
        _controller = GetComponent<Controller>();
        _weaponLoader = GetComponent<WeaponLoader>();
    }
    void Start()
    {
        //_weaponSprite = transform.Find("WeaponSprite").GetComponent<SpriteRenderer>();

        _controller.OnAttackEvent += OnShoot;
        _controller.OnLookEvent += OnAim;
    }
    private void OnAim(Vector2 newAimDirection)
    {
        _aimDirection = newAimDirection;
    }
    private void OnShoot()
    {
        CreateProjectile();
    }
    private void SetWeaponSprite()
    {

    }
    private void CreateProjectile()
    {
        weaponPrefab = SetingWeaponPrefab();

        //if (weaponPrefab != null)
        //{
        //    GameObject weaponSpriteObject = new GameObject("WeaponSprite");

        //    weaponSpriteObject.transform.SetParent(weaponPrefab.transform.Find("WeaponPivot"),false);

        //    SpriteRenderer weaponSpriteRenderer = weaponSpriteObject.AddComponent<SpriteRenderer>();

        //    WeaponData weaponData = weaponPrefab.GetComponent<WeaponData>();

        //    weaponSpriteRenderer.sprite = weaponData.weaponSprite;
        //}
    }

    //private int SetingWeaponDataType()
    //{
        
    //}

    public GameObject SetingWeaponPrefab()
    {

        WeaponDatas weaponData = _weaponLoader.weaponLoader;


        // 각 무기 데이터로부터 로드한 프리팹을 이용하여 무기 생성
            
        GameObject weaponPrefab = _weaponLoader.LoadWeaponPrefab(weaponData.Datas[1].weaponPrefabAddress); //프리팹의 주소를 받아옴

        // 무기 데이터를 이용하여 무기 설정
        GameObject weaponInstance = Instantiate(weaponPrefab, _weaponSpawnPoint.position, Quaternion.identity); // 그 주소로 생성
        Rigidbody2D _weaponRigidbody = weaponInstance.GetComponent<Rigidbody2D>();

        WeaponData _weaponData = weaponInstance.GetComponent<WeaponData>(); // 무기의 GameObject 데이터 설정을 위한 MonoBehaviour를 가지고있는 WeaponData로 가져옴
        _weaponData.type = weaponData.Datas[1].type;
        _weaponData.name = weaponData.Datas[1].name;
        _weaponData.damage = weaponData.Datas[1].damage;
        _weaponData.attackSpeed = weaponData.Datas[1].attackSpeed;
        _weaponData.speed = weaponData.Datas[1].speed;;

        if (playerSpeed.magnitude <= 0)
        {
            playerSpeed += _aimDirection;
        }

        // 무기 발사

        _weaponRigidbody.AddForce(playerSpeed + _aimDirection * _weaponData.speed, ForceMode2D.Impulse);

        Destroy(weaponInstance, 10f);

        return weaponPrefab;
    }

}
