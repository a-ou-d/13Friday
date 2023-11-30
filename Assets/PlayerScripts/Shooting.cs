using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Controller _controller;

    [SerializeField] private Transform _weaponSpawnPoint; // ���� ���Ⱑ ���� �� ��ġ �Դϴ�.

    private Vector2 _aimDirection = Vector2.zero; // � �������� ������ ���Ͱ� �Դϴ�.

    private float _weaponSpeed = 5;

    public GameObject tesGameObject; //������ ������
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

        Debug.Log("�߻�");

        GameObject projectile = Instantiate(tesGameObject, _weaponSpawnPoint.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = _aimDirection * Vector2.one * _weaponSpeed;
    }
}
