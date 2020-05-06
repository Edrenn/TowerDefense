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
    [SerializeField] Button boneUpgradeBtn;

    [SerializeField] Text damageUpgrade;
    [SerializeField] Button damageUpgradeBtn;

    [SerializeField] Text shootSpeedUpgrade;
    [SerializeField] Button shootUpgradeBtn;

    [SerializeField] Text availableUpgradePoints;
    private void Start()
    {
        GetGameDatas();
        AfterBuyUIUpdate();

        UpdateUpgradePoints();
        UpdateBoneUpgradeText();
        UpdateDamageUpgradeText();
        UpdateShootSpeedUpgradeText();
    }

    #region Bone
    public void UpgradeBoneKillIncome()
    {
        gameDatas.killIncomeBonus += 10;
        UpdateBoneUpgradeText();
        gameDatas.upgradePointsAvailable -= 1;
        AfterBuyUIUpdate();
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
        gameDatas.upgradePointsAvailable -= 1;
        AfterBuyUIUpdate();
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
        gameDatas.upgradePointsAvailable -= 1;
        AfterBuyUIUpdate();
    }

    private void UpdateShootSpeedUpgradeText()
    {
        shootSpeedUpgrade.text = gameDatas.towerShootSpeedBonus.ToString() + " %";
    }
    #endregion

    #region UpgradePoints
    private void UpdateUpgradePoints()
    {
        availableUpgradePoints.text = gameDatas.upgradePointsAvailable.ToString();
    }
    #endregion

    private void AfterBuyUIUpdate()
    {
        if (gameDatas.upgradePointsAvailable < 1)
        {
            SetAllButtonInteractable(false);
        }
        UpdateUpgradePoints();
    }

    private void SetAllButtonInteractable(bool isInteractable)
    {
        boneUpgradeBtn.interactable = isInteractable;
        damageUpgradeBtn.interactable = isInteractable;
        shootUpgradeBtn.interactable = isInteractable;
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
        FindObjectOfType<DataConveyer>().gameDatas = gameDatas;
        SaveSystem.SaveGeneric<CoreGameData>(gameDatas, CoreGameData.DATAKEY);
        FindObjectOfType<LevelLoader>().LoadLevelSelection();
    }
}
