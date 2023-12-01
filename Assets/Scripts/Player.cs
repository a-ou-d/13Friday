using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Controller
{
    GameObject Jason;
    GameObject Sadako;
    GameObject Pennywise;
    GameObject Saw;

    public void Awake()
    {
        Jason = new GameObject("Jason");
        Sadako = new GameObject("Sadako");
        Pennywise = new GameObject("Pennywise");
        Saw = new GameObject("Saw");
    }

    public void OnSkillEvent(InputValue value)
    {
        
        // 각 오브젝트의 활성화 여부를 직접 비교
        if ( Jason.activeSelf == true )
        {
            // 공격 스크립트에서 일시적으로 공격력 증가 함수
            Debug.Log("특수스킬사용");
        }
        else if ( Sadako.activeSelf == true )
        {
            // PlayerController의 worldPos 마우스 커서 위치로 순간이동
        }
        else if (Pennywise.activeSelf == true )
        {
            // GameManager에서 life +1 (최대 수치 정할 것), 잠시 동안 무적
        }
        else if (Saw.activeSelf == true )
        {
            // 공격 스크립트에서 일시적으로 공격 속도 증가 함수
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Enemy와 충돌했을 때의 처리
            PlayerTakeDamage();
        }
    }

    public void PlayerTakeDamage()
    {
        // GameManager의 Life -1 , DecreaseLifr 함수 만들어야함
        GameManager.Instance.DecreaseLife(1);
    }
}
