using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterChoice : MonoBehaviour
{
    public void OnCharacterChoose(string characterName)
    {
        PlayerPrefs.SetString("ChooseCharacter", characterName);
        SceneManager.LoadScene("MainScene");
    }
}
