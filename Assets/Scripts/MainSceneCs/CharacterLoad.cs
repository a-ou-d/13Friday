using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoad : MonoBehaviour
{
    public GameObject[] characterPrefabs;

    private void Start()
    {
        string selectedCharacterName = PlayerPrefs.GetString("SelectedCharacter", "Jason"); // �⺻ ĳ���ʹ� ���̽�
        foreach (var character in characterPrefabs)
        {
            if (character.name == selectedCharacterName)
            {
                Instantiate(character, Vector3.zero, Quaternion.identity); // ĳ���� ���� ��ġ
                break;
            }
        }
    }
}
