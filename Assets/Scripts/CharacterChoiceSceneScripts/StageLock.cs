using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLock : MonoBehaviour
{
    private const string StageUnlockKey = "StageUnlocked_";

    public static bool IsStageUnlocked(int stageNumber)
    {
        return PlayerPrefs.GetInt(StageUnlockKey + stageNumber, 0) == 1;
    }

    public static void UnlockStage(int stageNumber)
    {
        PlayerPrefs.SetInt(StageUnlockKey + stageNumber, 1);
        PlayerPrefs.Save();
    }
}
