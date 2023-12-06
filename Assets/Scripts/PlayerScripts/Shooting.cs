using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public enum WeaponType
{
    Machete,
    TV,
    Balloon,
    Saw,
}

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform _weaponSpawnPoint; // ���� ���Ⱑ ���� �� ��ġ �Դϴ�.
    private Vector2 _aimDirection = Vector2.zero; // � �������� ������ ���Ͱ� �Դϴ�.
    private Controller _controller;
    private WeaponLoader _weaponLoader;

    private SpriteRenderer _weaponSprite;

    private GameObject weaponPrefab;

    private float playerSpeed;

    public void SetPlayerSpeed(float speed)
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


    public GameObject SetingWeaponPrefab(int type)
    {

        WeaponDatas weaponData = _weaponLoader.weaponLoader;


        // �� ���� �����ͷκ��� �ε��� �������� �̿��Ͽ� ���� ����
            
        GameObject weaponPrefab = _weaponLoader.LoadWeaponPrefab(weaponData.Datas[type].weaponPrefabAddress); //�������� �ּҸ� �޾ƿ�



        // ���� �����͸� �̿��Ͽ� ���� ����
        GameObject weaponInstance = Instantiate(weaponPrefab, _weaponSpawnPoint.position, Quaternion.identity); // �� �ּҷ� ����
        Rigidbody2D _weaponRigidbody = weaponInstance.GetComponent<Rigidbody2D>();

        WeaponData _weaponData = weaponInstance.GetComponent<WeaponData>(); // ������ GameObject ������ ������ ���� MonoBehaviour�� �������ִ� WeaponData�� ������
        _weaponData.type = weaponData.Datas[type].type;
        _weaponData.name = weaponData.Datas[type].name;
        _weaponData.damage = weaponData.Datas[type].damage;
        _weaponData.attackSpeed = weaponData.Datas[type].attackSpeed;
        _weaponData.speed = weaponData.Datas[type].speed;;

        // float weaponSpeed = _weaponData.speed + playerSpeed;
        // ���� �߻�

        _weaponRigidbody.AddForce(_aimDirection * _weaponData.speed, ForceMode2D.Impulse);

        Destroy(weaponInstance, 10f);

        return weaponPrefab;
    }

}
