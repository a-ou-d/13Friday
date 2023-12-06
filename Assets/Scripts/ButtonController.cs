using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    WeaponLoader weaponLoader;

    private void Awake()
    {
        weaponLoader = GetComponent<WeaponLoader>();
    }

    public int getButtonValue;
    private int randomInt; 


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

        randomInt = Random.Range(5, 13);
        getButtonValue = OnButtonClick(randomInt);
        if (randomInt != getButtonValue)
        {
            getButtonValue = OnButtonClick(randomInt);
        }
        
    }

    private int OnButtonClick(int value)
    {
        return value;
    }

}
