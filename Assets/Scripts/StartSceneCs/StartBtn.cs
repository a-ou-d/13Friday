using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TMP_StartBtn : MonoBehaviour
{

    public void CharacterChoiceSceneLoad()
    {
        SceneManager.LoadScene("CharacterChoiceScene");
    }
}
