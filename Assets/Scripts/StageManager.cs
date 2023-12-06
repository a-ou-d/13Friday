using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class StageManager : MonoBehaviour
{
    public GameObject Stage1;
    public GameObject Stage2;
    public GameObject Stage3;
    public GameObject Stage4;
    private int currentStage;

    public void ChangeStage(int stageNumber)
    {
        currentStage = stageNumber;

        switch (stageNumber)
        {
            case 1:
                Stage1.SetActive(true);
                Stage2.SetActive(false);
                Stage3.SetActive(false);
                Stage4.SetActive(false);
                break;
            case 2:
                Stage1.SetActive(false);
                Stage2.SetActive(true);
                Stage3.SetActive(false);
                Stage4.SetActive(false);
                break;
            case 3:
                Stage1.SetActive(false);
                Stage2.SetActive(false);
                Stage3.SetActive(true);
                Stage4.SetActive(false);
                break;
            case 4:
                Stage1.SetActive(false);
                Stage2.SetActive(false);
                Stage3.SetActive(false);
                Stage4.SetActive(true);
                break;
            default:
                break;
        }
    }


    public void Restart()
    {
        switch (currentStage)
        {
            case 1:
                ResetStage(Stage1);
                break;
            case 2:
                ResetStage(Stage2);
                break;
            case 3:
                ResetStage(Stage3);
                break;
            case 4:
                ResetStage(Stage4);
                break;
            default:
                break;
        }
    }


    public void ResetStage(GameObject stage)
    {
        //플레이어 위치 초기화
        //점수 초기화
        //장애물 및 적 초기화
        //등등 추가
        //씬매니저로 해당 씬 로드하면 될 것 같습니다.
    }
}
