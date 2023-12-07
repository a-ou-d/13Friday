using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour // ������ ĳ������ �������� ���� ���� �ε�
{
    public GameObject jasonPrefab;
    public GameObject sadakoPrefab;
    public GameObject pennywisePrefab;
    public GameObject jigsawPrefab;


    private void Start()
    {
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter", "Jason");
        LoadSelectedCharacter(selectedCharacter);
    }

    private void LoadSelectedCharacter(string characterName)
    {
        GameObject characterPrefab = null;

        switch (characterName)
        {
            case "Jason":
                characterPrefab = jasonPrefab;
                break;
            case "Sadako":
                characterPrefab = sadakoPrefab;
                break;
            case "Pennywise":
                characterPrefab = pennywisePrefab;
                break;
            case "Jigsaw":
                characterPrefab = jigsawPrefab;
                break;
        }

        if (characterPrefab != null)
        {
            Instantiate(characterPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}
