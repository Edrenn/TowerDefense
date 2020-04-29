using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[Serializable]
public class TowerData
{
    public const string DATAKEY = "TowerDatas";

    public string towerName;
    public int boneBuyPrice;
    public int boneSellPrice;
    public int experienceOnHit;
    public List<TowerLevel> levels;
    public float towerRange;
    public int damage;
    public float shotSpeed;

    public TowerData(Tower tower)
    {
        this.boneBuyPrice = tower.boneBuyPrice;
        this.experienceOnHit = tower.experienceOnHit;
        this.levels = tower.levels;

    }

    public TowerData()
    {

    }

    public TowerData(string towerName, int boneBuyPrice, int experienceOnHit, List<TowerLevel> levels, float towerRange, int damage, float shotSpeed)
    {
        this.towerName = towerName;
        this.boneBuyPrice = boneBuyPrice;
        this.experienceOnHit = experienceOnHit;
        this.levels = levels;
        this.towerRange = towerRange;
        this.damage = damage;
        this.shotSpeed = shotSpeed;
    }
}
