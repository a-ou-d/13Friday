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


    public void SetweponUI(int index) // 인덱스를 받아서 그에 해당하는 데이터를 세팅하는 함수입니다.
    {
        WeaponDatas weaponData = WeaponLoader.LoadWeaponData();

        Sprite weaponSprite = WeaponLoader.LoadSprite(weaponData.Datas[index].weaponSpriteAddress);
        for (int i = 0; i < weaponButtons.Length; i++)
        {
            weaponImage[i].sprite = weaponSprite;
            weaponNameText[i].text = weaponData.Datas[index].name;
            weaponDamageText[i].text = "공격력:" + weaponData.Datas[index].damage.ToString();
            weaponAttackSpeedText[i].text = "공격속도:" + weaponData.Datas[index].attackSpeed.ToString();
            weaponProjectileSpeedText[i].text = "투사체속도:" + weaponData.Datas[index].speed.ToString();
        }
        

    }

}
