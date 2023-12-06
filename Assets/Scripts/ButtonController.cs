using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
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

    private int OnButtonClick(int value)
    {
        return value;
    }

}
