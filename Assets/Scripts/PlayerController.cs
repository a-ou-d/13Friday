using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Controller
{
    SpriteRenderer spriteRenderer;
    private Camera _camera;
    private void Awake()
    {
        _camera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        if (newAim.magnitude >= .9f)
        {
            CallLookEvent(newAim);
        }

        //if (newAim.x != 0)
        //{
        //    spriteRenderer.flipX = newAim.x < 0;
        //}
    }

    public void OnFire(InputValue value)
    {
        Debug.Log("OnFire" + value.ToString());
        _isAttacking = value.isPressed;

    }

}
