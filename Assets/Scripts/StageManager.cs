using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
using UnityEditor.Experimental.GraphView;

public class StageManager : MonoBehaviour // 스테이지 관리
{
    public EnemyBoss boss;
    public GameObject[] stages;
    private int currentStage = -1;


    private void Update()
    {
        if (boss != null && boss.Isdie())
        {
            ClearStage();
        }
    }

    public void ClearStage()
    {
        currentStage++;
        UnlockCharacterForNextStage();
        MoveToNextStage();
        ShowClearScene();
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

    private void MoveToNextStage()
    {
        if (currentStage + 1 < stages.Length)
        {
            for (int i = 0; i < stages.Length; i++)
            {
                stages[i].SetActive(i == currentStage + 1);
            }
        }
        else
        {
            SceneManager.LoadScene("EndingScene");
        }
    }

    private void ShowClearScene()
    {
        SceneManager.LoadScene("StageClear");
    }
}
