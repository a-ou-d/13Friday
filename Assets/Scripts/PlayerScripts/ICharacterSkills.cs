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
        Debug.Log("Jason ��ų���");
    }
}
public class Sadako : MonoBehaviour, ICharacterSkills
{
    public void UseSkill()
    {
        Debug.Log("Sadako ��ų���");
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        transform.position = worldPos;
    }
}
public class Pennywise : MonoBehaviour, ICharacterSkills
{
    public void UseSkill()
    {
        Debug.Log("Pennywise ��ų���");
        // 5�� ���� ������ ���� ����
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
        Debug.Log("Saw ��ų���");
        // Saw�� ��ų ����
        // 10�� ���� ���� �ӵ� ���
        // AttackDelay�� ���̱�
    }
}