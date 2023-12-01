using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TMP_ExitBtn : MonoBehaviour
{

    public void ExitSceneLoad()
    {
        SceneManager.LoadScene("ExitScene");
    }
}
