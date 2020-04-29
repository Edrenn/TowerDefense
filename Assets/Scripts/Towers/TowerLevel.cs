using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TowerLevel
{
    public int experienceToUpgrade;
    public int levelIndex;
    public int upgradePrice;

    public TowerLevel()
    {
            
    }
    public TowerLevel(int experienceToUpgrade, int levelIndex, int upgradePrice)
    {
        this.experienceToUpgrade = experienceToUpgrade;
        this.levelIndex = levelIndex;
        this.upgradePrice = upgradePrice;
    }
}
