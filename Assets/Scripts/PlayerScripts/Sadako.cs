using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sadako : MonoBehaviour, ICharacterSkills
{
    public void UseSkill()
    {
        Debug.Log("Sadako 스킬사용");
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);

    }
}
