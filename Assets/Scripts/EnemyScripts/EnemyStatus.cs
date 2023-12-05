using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStatus
{
    public EnemyType _enemyType { get; }
    public string _name { get; set; }
    public int _hp { get; set; }
    public float _speed { get; set; }

    public EnemyStatus()
    {

    }

    public EnemyStatus(EnemyType enemyType, string name, int hp, float speed)
    {
        _enemyType = enemyType;
        _name = name;
        _hp = hp;
        _speed = speed;
    }

    public EnemyStatus SetStatus(EnemyType enemyType)
    {
        EnemyStatus enemyStatus = null;

        switch (enemyType)
        {
            case EnemyType.CampFire:
                enemyStatus = new EnemyStatus(enemyType, "CampFire", 100, 2f);
                break;
            case EnemyType.TableChair:
                enemyStatus = new EnemyStatus(enemyType, "TableChair", 100, 4f);
                break;
            case EnemyType.Wood:
                enemyStatus = new EnemyStatus(enemyType, "Wood", 100, 2f);
                break;
            case EnemyType.Kotatsu:
                enemyStatus = new EnemyStatus(enemyType, "Kotatsu", 100, 3f);
                break;
            case EnemyType.Ball:
                enemyStatus = new EnemyStatus(enemyType, "Ball", 100, 5f);
                break;
            case EnemyType.CircusRing:
                enemyStatus = new EnemyStatus(enemyType, "CircusRing", 100, 5f);
                break;
            case EnemyType.MerryGoRound:
                enemyStatus = new EnemyStatus(enemyType, "MerryGoRound", 100, 5f);
                break;
            case EnemyType.Drill:
                enemyStatus = new EnemyStatus(enemyType, "Drill", 100, 7f);
                break;
        }

        return enemyStatus;
    }
}

public class EnemyBossStatus
{
    public EnemyBossType _enemyBossType { get; }
    public string _name { get; set; }
    public int _hp { get; set; }
    public float _speed { get; set; }

    public EnemyBossStatus()
    {

    }

    public EnemyBossStatus(EnemyBossType enemyBossType, string name, int hp, float speed)
    {
        _enemyBossType = enemyBossType;
        _name = name;
        _hp = hp;
        _speed = speed;
    }

    public EnemyBossStatus SetStatus(EnemyBossType enemyBossType)
    {
        EnemyBossStatus enemyBossStatus = null;

        switch (enemyBossType)
        {
            case EnemyBossType.Boss1:
                enemyBossStatus = new EnemyBossStatus(enemyBossType, "Boss1", 1000, 6f);
                break;
        }

        return enemyBossStatus;
    }
}
