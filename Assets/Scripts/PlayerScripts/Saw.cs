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
        Debug.Log("Saw ��ų���");

        // Saw�� ��ų ����
        // 5�� ���� ���� �ӵ� ���
        // AttackDelay�� ���̱�
        _controller.SetIsUsingSkill(true);
        StartCoroutine(ResetSkill());
    }

    private IEnumerator ResetSkill()
    {
        yield return new WaitForSeconds(5f);
        _controller.SetIsUsingSkill(false);
    }
}