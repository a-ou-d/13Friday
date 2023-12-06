using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sadako : MonoBehaviour, ICharacterSkills
{
    public void UseSkill()
    {
        Debug.Log("Sadako ��ų���");
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);

    }
}
