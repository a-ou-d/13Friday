using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
