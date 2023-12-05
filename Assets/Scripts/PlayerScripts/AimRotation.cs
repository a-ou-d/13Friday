using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer armRenderer;
    [SerializeField] private Transform armPivot;
    [SerializeField] private SpriteRenderer charcterRenderer;

    private Controller _controller;
    // Start is called before the first frame update
    private void Awake()
    {
        _controller = GetComponent<Controller>();
    }
    void Start()
    {
        _controller.OnLookEvent += OnAim;
    }

    // Update is called once per frame

    public void OnAim(Vector2 newAimDiretion)
    {
        RotateArm(newAimDiretion);
    }

    private void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        armRenderer.flipY = Mathf.Abs(rotZ) > 90f;
        charcterRenderer.flipX = armRenderer.flipY;
        armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
