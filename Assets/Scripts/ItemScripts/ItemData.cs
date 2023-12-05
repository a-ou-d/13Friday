using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/ItemData")]
public class ItemData : ScriptableObject
{
    [Header("Main Info")]
    public string name;
    public string desc;
    public Sprite icon;

    [Header("Option Data")]
    public int recover;
    public float damages;
    public float speed;
    public float dropProbability;

    [Header("Item")]
    public GameObject itemPrefab;
}
