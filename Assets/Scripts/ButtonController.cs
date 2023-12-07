using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{
    WeaponLoader weaponLoader;
    UIManager uiUIManager;
    private void Awake()
    {
        weaponLoader = GetComponent<WeaponLoader>();
        uiUIManager = GetComponent<UIManager>();
    }

    public int getButtonValue;



    public void OnButtonClick0()
    {
        getButtonValue = OnButtonClick(0);
    }
    public void OnButtonClick1()
    {
        getButtonValue = OnButtonClick(1);
    }
    public void OnButtonClick2()
    {
        getButtonValue = OnButtonClick(2);
    }
    public void OnButtonClick3()
    {
        getButtonValue = OnButtonClick(3);
    }

    public void OnButtonRandom()
    {
        int randomInt = uiUIManager.GetLastClickedIndex();
        getButtonValue = OnButtonClick(randomInt);
        SceneManager.LoadScene("CharacterChoiceScene");
    }

    private int OnButtonClick(int value)
    {
        return value;
    }

}
