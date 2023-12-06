using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour, ICharacterSkills
{
    private Controller _controller;

    private void Start()
    {
        _controller = GetComponent<Controller>();
    }

    public void UseSkill()
    {
        Debug.Log("Saw 스킬사용");

        // Saw의 스킬 구현
        // 5초 동안 공격 속도 상승
        // AttackDelay를 줄이기
        _controller.SetIsUsingSkill(true);
        StartCoroutine(ResetSkill());
    }

    private IEnumerator ResetSkill()
    {
        yield return new WaitForSeconds(5f);
        _controller.SetIsUsingSkill(false);
    }
}