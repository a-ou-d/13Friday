using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Controller : MonoBehaviour
{

    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;
    public event Action OnSkillEvent;
    private float _originalAttackDelay = 0.2f;
    private float _timeSinceLastAttack;
    protected bool _isAttacking { get; set; }
    private bool _isUsingSkill;
    protected virtual void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {

        float currentAttackDelay = _isUsingSkill ? _originalAttackDelay / 2f : _originalAttackDelay;

        if (_timeSinceLastAttack <= currentAttackDelay)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }
        else if (_isAttacking && _timeSinceLastAttack > currentAttackDelay)
        {
            _timeSinceLastAttack = 0f;
            CallAttackEvent();
        }


    }
    public void SetIsUsingSkill(bool isUsingSkill)
    {
        _isUsingSkill = isUsingSkill;
    }
    public float GetOriginalAttackDelay()
    {
        return _originalAttackDelay;
    }
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }

    public void CallOnSkill()
    {
        OnSkillEvent?.Invoke();
    }
}
