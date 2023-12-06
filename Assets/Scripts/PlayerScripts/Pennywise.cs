using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
