using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public interface ICharacterSkills
{
    void UseSkill();
}
public class Jason : MonoBehaviour, ICharacterSkills
{
    public void UseSkill()
    {
        Debug.Log("Jason 스킬사용");
    }
}
public class Sadako : MonoBehaviour, ICharacterSkills
{
    public void UseSkill()
    {
        Debug.Log("Sadako 스킬사용");
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        transform.position = worldPos;
    }
}
public class Pennywise : MonoBehaviour, ICharacterSkills
{
    public void UseSkill()
    {
        Debug.Log("Pennywise 스킬사용");
        // 5초 동안 데미지 받지 않음
        Player playerScript = GetComponent<Player>();
        if (playerScript != null)
        {
            playerScript.StartCoroutine(playerScript.DisableDamageForSeconds(5f));
        }
    }
}
public class Saw : MonoBehaviour, ICharacterSkills
{
    public void UseSkill()
    {
        Debug.Log("Saw 스킬사용");
        // Saw의 스킬 구현
        // 10초 동안 공격 속도 상승
        // AttackDelay를 줄이기
    }
}