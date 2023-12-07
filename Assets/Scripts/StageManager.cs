using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
using UnityEditor.Experimental.GraphView;

public class StageManager : MonoBehaviour // 스테이지 관리 + 캐릭터,스테이지 잠금 해제
{
    public EnemyBoss boss;
    public GameObject[] stages;
    private int currentStage = -1;

    private void Start()
    {
        UnlockFirstStage();
    }

    public void UnlockFirstStage()
    {
        int firstStage = 0;

        if (!StageLock.IsStageUnlocked(firstStage))
        {
            StageLock.UnlockStage(firstStage);
        }
    }


    public void ClearStage()
    {
        currentStage++; // 현재 스테이지 증가
        UnlockCharacterForNextStage(); // 캐릭터 잠금 해제
        ShowClearScene(); // 클리어씬 호출

        StageLock.UnlockStage(currentStage + 1);
    }

    private void UnlockCharacterForNextStage()
    {
        switch (currentStage)
        {
            case 0:
                CharacterLock.UnlockCharacter("Sadako");
                break;
            case 1:
                CharacterLock.UnlockCharacter("Pennywise");
                break;
            case 2:
                CharacterLock.UnlockCharacter("Jigsaw");
                break;
        }
    }

    private void ShowClearScene()
    {
        SceneManager.LoadScene("StageClear");
    }

    public void ChangeStage(int stageNumber)
    {
        if (stageNumber >= 0 && stageNumber < stages.Length)
        {
            currentStage = stageNumber;
            for (int i = 0; i < stages.Length; i++)
            {
                stages[i].SetActive(i == stageNumber);
            }
        }
        else
        {
            Debug.LogError("Invalid stage number: " + stageNumber);
        }
    }

    public void RestartStage()
    {
        ChangeStage(currentStage);
    }
}
