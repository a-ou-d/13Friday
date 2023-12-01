using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TMP_BackBtn : MonoBehaviour
{

    public void BackSceneLoad()
    {
        SceneManager.LoadScene("StartScene");
    }
}
