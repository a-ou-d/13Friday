using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private WeaponLoader WeaponLoader;
    public Image[] weaponImage;
    public Text[] weaponNameText;
    public Text[] weaponDamageText;
    public Text[] weaponAttackSpeedText;
    public Text[] weaponProjectileSpeedText;
    public Button[] weaponButtons;

    private int lastClickedIndex = -1;
    private void Start()
    {
        WeaponLoader = GetComponent<WeaponLoader>();

        SetweponUI();
        AddButtonListeners();
    }

    private void AddButtonListeners()
    {
        for (int i = 0; i < weaponButtons.Length; i++)
        {
            int buttonIndex = i;
            weaponButtons[i].onClick.AddListener(() => HandleButtonClick(buttonIndex));
        }
    }

    public void SetweponUI() // �ε����� �޾Ƽ� �׿� �ش��ϴ� �����͸� �����ϴ� �Լ��Դϴ�.
    {
        WeaponDatas weaponData = WeaponLoader.LoadWeaponData();
        
        for(int i = 0; i < weaponButtons.Length; i++)
        {
            int randomIndex = Random.Range(5, weaponData.Datas.Count);
      
            weaponImage[i].sprite = WeaponLoader.LoadSprite(weaponData.Datas[randomIndex].weaponSpriteAddress);
            weaponNameText[i].text = weaponData.Datas[randomIndex].name;
            weaponDamageText[i].text = "���ݷ�:" + weaponData.Datas[randomIndex].damage.ToString();
            weaponAttackSpeedText[i].text = "���ݼӵ�:" + weaponData.Datas[randomIndex].attackSpeed.ToString();
            weaponProjectileSpeedText[i].text = "����ü�ӵ�:" + weaponData.Datas[randomIndex].speed.ToString();
        }
        
    }

    private void HandleButtonClick(int buttonIndex)
    {
        lastClickedIndex = buttonIndex;
    }

    public int GetLastClickedIndex()
    {
        return lastClickedIndex;   
    }
}
