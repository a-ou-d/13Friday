using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLoader : MonoBehaviour
{
    private string weaponJsonFile = "JSON/Weapon";
    public WeaponDatas weaponLoader;

    private void Start()
    {
        weaponLoader = LoadWeaponData();
    }


    public WeaponDatas LoadWeaponData()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>(weaponJsonFile);
        WeaponDatas dataList = JsonUtility.FromJson<WeaponDatas>(jsonFile.ToString());
        Debug.Log(dataList.ToString());

        return dataList;
    }

    public GameObject LoadWeaponPrefab(string prefabAddress)
    {
        return Resources.Load<GameObject>(prefabAddress);
    }
    public Sprite LoadSprite(string spriteAddress)
    {
        return Resources.Load<Sprite>(spriteAddress);
    }

}
