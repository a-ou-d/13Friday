using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterChoiceManager : MonoBehaviour // 캐릭터선택 UI, 선택 캐릭터 저장
{
    public GameObject sadakoLock;
    public Button sadakoButton;

    public GameObject pennywiseLock;
    public Button pennywiseButton;

    public GameObject jigsawLock;
    public Button jigsawButton;

    public GameObject StageChoice;


    private void Start()
    {
        CharacterButtonOn();
    }

    private void CharacterButtonOn()
    {
        if (CharacterLock.IsCharacterUnlocked("Sadako"))
        {
            sadakoLock.SetActive(false);
            sadakoButton.interactable = true;
        }
        if (CharacterLock.IsCharacterUnlocked("Pennywise"))
        {
            pennywiseLock.SetActive(false);
            pennywiseButton.interactable = true;
        }
        if (CharacterLock.IsCharacterUnlocked("Jigsaw"))
        {
            jigsawLock.SetActive(false);
            jigsawButton.interactable = true;
        }
    }

    public void SelectCharacter(string characterName)
    {
        PlayerPrefs.SetString("SelectedCharacter", characterName);
        StageChoice.SetActive(true);
    }
}
