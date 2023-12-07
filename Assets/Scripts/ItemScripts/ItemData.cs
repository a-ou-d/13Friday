using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/ItemData")]
public class ItemData : ScriptableObject
{
    [Header("Main Info")]
    public ItemType itemType;
    public string name;
    public string desc;
    public Sprite icon;

    [Header("Option Data")]
    public int recover;
    public int damages;
    public float speed;
    public float dropProbability;

    [Header("Item")]
    public GameObject itemPrefab;

    public enum ItemType
    {
        Recover,
        Damage,
        Speed,
    }
}
