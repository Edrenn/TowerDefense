using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public CoreGameData gameDatas;

    [SerializeField] Text boneUpgrade;

    private void Start()
    {
        GetGameDatas();
        UpdateBoneUpgradeText();
    }

    public void UpgradeBoneKillIncome()
    {
        gameDatas.killIncomeBonus += 10;
        UpdateBoneUpgradeText();
    }

    private void UpdateBoneUpgradeText()
    {
        boneUpgrade.text = gameDatas.killIncomeBonus.ToString() +" %";
    }

    private void GetGameDatas()
    {
        DataConveyer dc = FindObjectOfType<DataConveyer>();
        if (!dc)
        {
            gameDatas = SaveSystem.LoadGeneric<CoreGameData>(CoreGameData.DATAKEY);
        }
        else
        {
            gameDatas = dc.gameDatas;
        }
    }

    public void SaveAndReturn()
    {
        SaveSystem.SaveGeneric<CoreGameData>(gameDatas, CoreGameData.DATAKEY);
        FindObjectOfType<LevelLoader>().LoadLevelSelection();
    }
}
