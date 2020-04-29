using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Extension;

public class UpgradeManager : MonoBehaviour
{
    public CoreGameData gameDatas;

    [SerializeField] Text boneUpgrade;
    [SerializeField] Text damageUpgrade;
    [SerializeField] Text shootSpeedUpgrade;

    private void Start()
    {
        GetGameDatas();
        UpdateBoneUpgradeText();
        UpdateDamageUpgradeText();
        UpdateShootSpeedUpgradeText();
    }

    #region Bone
    public void UpgradeBoneKillIncome()
    {
        gameDatas.killIncomeBonus += 10;
        UpdateBoneUpgradeText();
    }

    private void UpdateBoneUpgradeText()
    {
        boneUpgrade.text = gameDatas.killIncomeBonus.ToString() + " %";
    }
    #endregion

    #region Damage
    public void UpgradeDamage()
    {
        gameDatas.towerDamageBonus += 50;
        UpdateDamageUpgradeText();
    }

    private void UpdateDamageUpgradeText()
    {
        damageUpgrade.text = gameDatas.towerDamageBonus.ToString() + " %";
    }
    #endregion

    #region ShootSpeed
    public void UpgradeShootSpeed()
    {
        gameDatas.towerShootSpeedBonus += 20;
        UpdateShootSpeedUpgradeText();
    }

    private void UpdateShootSpeedUpgradeText()
    {
        shootSpeedUpgrade.text = gameDatas.towerShootSpeedBonus.ToString() + " %";
    }
    #endregion

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
