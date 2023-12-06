using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoad : MonoBehaviour
{
    public GameObject[] characterPrefabs;

    private void Start()
    {
        string selectedCharacterName = PlayerPrefs.GetString("SelectedCharacter", "Jason"); // 기본 캐릭터는 제이슨
        foreach (var character in characterPrefabs)
        {
            if (character.name == selectedCharacterName)
            {
                Instantiate(character, Vector3.zero, Quaternion.identity); // 캐릭터 시작 위치
                break;
            }
        }
    }
}
