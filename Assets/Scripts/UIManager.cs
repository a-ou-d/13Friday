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

    private void Start()
    {
        int randomindex = Random.Range(5, 13);
        WeaponLoader = GetComponent<WeaponLoader>();

        for (int i = 0; i < weaponButtons.Length; i++)
        {
            randomindex = Random.Range(5, 13);
            SetweponUI(randomindex);          
        }

    }


    public void SetweponUI(int index) // �ε����� �޾Ƽ� �׿� �ش��ϴ� �����͸� �����ϴ� �Լ��Դϴ�.
    {
        WeaponDatas weaponData = WeaponLoader.LoadWeaponData();

        Sprite weaponSprite = WeaponLoader.LoadSprite(weaponData.Datas[index].weaponSpriteAddress);
        for (int i = 0; i < weaponButtons.Length; i++)
        {
            weaponImage[i].sprite = weaponSprite;
            weaponNameText[i].text = weaponData.Datas[index].name;
            weaponDamageText[i].text = "���ݷ�:" + weaponData.Datas[index].damage.ToString();
            weaponAttackSpeedText[i].text = "���ݼӵ�:" + weaponData.Datas[index].attackSpeed.ToString();
            weaponProjectileSpeedText[i].text = "����ü�ӵ�:" + weaponData.Datas[index].speed.ToString();
        }
        

    }

}
