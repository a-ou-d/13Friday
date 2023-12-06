using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageChoiceManager : MonoBehaviour // 스테이지선택 UI, 선택 스테이지 저장
{
    public Button stage1Btn;
    public Button stage2Btn;
    public Button stage3Btn;
    public Button stage4Btn;

    private void Start()
    {
        StageButtonOn();
    }

    private void StageButtonOn()
    {
        stage2Btn.interactable = StageLock.IsStageUnlocked(2);
        stage3Btn.interactable = StageLock.IsStageUnlocked(3);
        stage4Btn.interactable = StageLock.IsStageUnlocked(4);

        if (!StageLock.IsStageUnlocked(1))
        {
            stage1Btn.interactable = true;
        }
    }

    public void LoadStage(int stageNumber)
    {
        string sceneName = "MainScene";

        StageManager stageManager = FindObjectOfType<StageManager>();
        if (stageManager != null)
        {
            stageManager.ChangeStage(stageNumber);
        }

        SceneManager.LoadScene(sceneName);
    }
}
