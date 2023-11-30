using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Controller _controller;

    [SerializeField] private Transform _weaponSpawnPoint; // 던질 무기가 생성 될 위치 입니다.

    private Vector2 _aimDirection = Vector2.zero; // 어떤 방향으로 던지는 벡터값 입니다.

    private float _weaponSpeed = 5;

    public GameObject tesGameObject; //무기의 프리팹
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
        CreateProjectile();
        
    }

    private void CreateProjectile()
    {

        Debug.Log("발사");

        GameObject projectile = Instantiate(tesGameObject, _weaponSpawnPoint.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = _aimDirection * Vector2.one * _weaponSpeed;
    }
}
