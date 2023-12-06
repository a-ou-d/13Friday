using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
