using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TMP_ShopBtn : MonoBehaviour
{
    public void ShopSceneLoad()
    {
        SceneManager.LoadScene("ShopScene");
    }
}
