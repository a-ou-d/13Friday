using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Controller
{
    SpriteRenderer spriteRenderer;
    private Camera _camera;
    private ICharacterSkills characterSkills;
    public Vector2 Aim;

    private bool skillCooldown = false;

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
        Aim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(Aim);
        Aim = (worldPos - (Vector2)transform.position).normalized;
        if (Aim.magnitude >= .9f)
        {
            CallLookEvent(Aim);
        }
    }

    public void OnFire(InputValue value)
    {
        Debug.Log("OnFire" + value.ToString());
        _isAttacking = value.isPressed;
    }

    public void SetCharacterSkills(ICharacterSkills skills)
    {
        characterSkills = skills;
    }

    public void OnSkill()
    {
        if (!skillCooldown)
        {
            StartCoroutine(SkillCooldown());
        }
        else
        {
            Debug.Log("Skill on cooldown. Wait for cooldown to finish.");
        }
    }

    private IEnumerator SkillCooldown()
    {
        skillCooldown = true;

        Debug.Log(characterSkills);
        if (characterSkills != null)
        {
            characterSkills.UseSkill();
        }
        else
        {
            Debug.LogWarning("CharacterSkills is null.");
        }

        // 15√  ¥Î±‚
        yield return new WaitForSeconds(15f);
        skillCooldown = false;
    }
}
