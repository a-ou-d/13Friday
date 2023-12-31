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
                enemyStatus = new EnemyStatus(enemyType, "CampFire", 20, 0.5f);
                break;
            case EnemyType.TableChair:
                enemyStatus = new EnemyStatus(enemyType, "TableChair", 30, 0.8f);
                break;
            case EnemyType.Wood:
                enemyStatus = new EnemyStatus(enemyType, "Wood", 35, 1f);
                break;
            case EnemyType.Kotatsu:
                enemyStatus = new EnemyStatus(enemyType, "Kotatsu", 50, 1.2f);
                break;
            case EnemyType.Ball:
                enemyStatus = new EnemyStatus(enemyType, "Ball", 150, 1f);
                break;
            case EnemyType.CircusRing:
                enemyStatus = new EnemyStatus(enemyType, "CircusRing", 150, 1.5f);
                break;
            case EnemyType.MerryGoRound:
                enemyStatus = new EnemyStatus(enemyType, "MerryGoRound", 200, 2f);
                break;
            case EnemyType.Drill:
                enemyStatus = new EnemyStatus(enemyType, "Drill", 100, 4f);
                break;
        }


        return enemyStatus;
    }
}

public class EnemyNamedStatus
{
    public EnemyNamedType _enemyNamedType { get; }
    public string _name { get; set; }
    public int _hp { get; set; }
    public float _speed { get; set; }

    public EnemyNamedStatus()
    {

    }

    public EnemyNamedStatus(EnemyNamedType enemyNamedType, string name, int hp, float speed)
    {
        _enemyNamedType = enemyNamedType;
        _name = name;
        _hp = hp;
        _speed = speed;
    }

    public EnemyNamedStatus SetStatus(EnemyNamedType enemyNamedType)
    {
        EnemyNamedStatus enemyNamedStatus = null;

        switch (enemyNamedType)
        {
            case EnemyNamedType.Named1:
                enemyNamedStatus = new EnemyNamedStatus(enemyNamedType, "Named1", 300, 3f);
                break;
        }

        return enemyNamedStatus;
    }
}

public class EnemyBossStatus
{
    public EnemyBossType _enemyBossType { get; }
    public string _name { get; set; }
    public int _hp { get; set; }
    public float _speed { get; set; }
    public float _keepDistance { get; set; }

    public EnemyBossStatus()
    {

    }

    public EnemyBossStatus(EnemyBossType enemyBossType, string name, int hp, float speed, float keepDistance)
    {
        _enemyBossType = enemyBossType;
        _name = name;
        _hp = hp;
        _speed = speed;
        _keepDistance = keepDistance;
    }

    public EnemyBossStatus SetStatus(EnemyBossType enemyBossType)
    {
        EnemyBossStatus enemyBossStatus = null;

        switch (enemyBossType)
        {
            case EnemyBossType.Boss1:
                enemyBossStatus = new EnemyBossStatus(enemyBossType, "Boss1", 500, 6f, 5f);
                break;
        }

        return enemyBossStatus;
    }
}
