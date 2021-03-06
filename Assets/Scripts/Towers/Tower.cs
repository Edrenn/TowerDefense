﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // prices
    public int boneBuyPrice;
    public int boneSellPrice;

    // leveling
    public List<TowerLevel> levels;
    private int currentExperience;
    [SerializeField] private int experienceOnHit;
    private int currentLevelIndex;
    private bool readyToUpgrade;
    private bool maxLevelReached;

    public Sprite towerSprite;
    public TowerSpawner parentSpawner;

    [SerializeField] private GameObject towerInterface;
    [SerializeField] private TowerLevelUI towerLevelUI;

    private void Start()
    {
        UpdateTowerLevelUI();
        boneSellPrice = Mathf.RoundToInt(boneBuyPrice * 0.7f);
        UpdateTowerInterface();
    }

    private void OnDestroy()
    {
        parentSpawner.gameObject.SetActive(true);
    }

    private void OnMouseDown()
    {
        Debug.Log("Tower");
        if (towerInterface.activeInHierarchy)
        {
            towerInterface.SetActive(false);
        }
        else
            towerInterface.SetActive(true);
    }

    public void KillAnAttacker(Attacker target)
    {
        if (!maxLevelReached && !readyToUpgrade)
        {
            currentExperience += target.experienceValue;
            Debug.Log("Current Xp : " + currentExperience);
            if (currentExperience >= levels[currentLevelIndex].experienceToUpgrade)
            {
                readyToUpgrade = true;
                towerLevelUI.SetUpgradeVisibility(true);
                Debug.Log("Ready to upgrade !");
            }
        }
    }

    public void HitAnAttacker()
    {
        if (!maxLevelReached && !readyToUpgrade)
        {
            currentExperience += experienceOnHit;
            Debug.Log("Current Xp : " + currentExperience);
            if (currentExperience >= levels[currentLevelIndex].experienceToUpgrade)
            {
                readyToUpgrade = true;
                towerLevelUI.SetUpgradeVisibility(true);
                Debug.Log("Ready to upgrade !");
            }
        }
    }

    public void TryToUpgrade()
    {
        CoreGame coreGame = FindObjectOfType<CoreGame>();
        if (coreGame)
        {
            if (readyToUpgrade && coreGame.SpendBones(levels[currentLevelIndex].upgradePrice))
            {
                boneSellPrice += Mathf.RoundToInt(levels[currentLevelIndex].upgradePrice * 0.7f);
                currentLevelIndex++;
                if (currentLevelIndex >= levels.Count-1)
                {
                    maxLevelReached = true;
                    towerLevelUI.UpdateLevel("Maxed");
                }
                else
                    UpdateTowerLevelUI();
                readyToUpgrade = false;
                towerLevelUI.SetUpgradeVisibility(false);
                currentExperience = 0;
                GetComponentInChildren<Shooter>().Upgrade(1, 0.5f);
                UpdateTowerInterface();
            }
            else
            {
                // Feed back can't buy
                Debug.Log("Can't upgrade for not enough bones or xp");
            }
        }
    }

    private void UpdateTowerLevelUI()
    {
        towerLevelUI.UpdateLevel((currentLevelIndex + 1).ToString());
    }

    private void UpdateTowerInterface()
    {
        towerInterface.GetComponentInChildren<TowerSeller>().UpdatePrice(this.boneSellPrice);
        if (!maxLevelReached)
            towerInterface.GetComponentInChildren<TowerUpgrade>().UpdatePrice(this.levels[currentLevelIndex].upgradePrice);
        else
            towerInterface.GetComponentInChildren<TowerUpgrade>().UpgradeMaxedLevel();

        this.towerInterface.SetActive(false);
    }
}
