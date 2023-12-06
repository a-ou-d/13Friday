using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageChoiceManager : MonoBehaviour
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
        stage1Btn.interactable = StageLock.IsStageUnlocked(1);
        stage2Btn.interactable = StageLock.IsStageUnlocked(2);
        stage3Btn.interactable = StageLock.IsStageUnlocked(3);
        stage4Btn.interactable = StageLock.IsStageUnlocked(4);
    }

    public void LoadStage(int stageNumber)
    {
        StageManager stageManager = FindObjectOfType<StageManager>();

        if (stageManager != null)
        {
            stageManager.ChangeStage(stageNumber);
        }
        else
        {
            Debug.LogError("StageManager not found in the scene!");
        }
    }
}
