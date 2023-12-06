using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextBtn : MonoBehaviour
{
    public void OnNextBtn()
    {
        SceneManager.LoadScene("CharacterChoiceScene");
    }
}
