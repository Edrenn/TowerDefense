using UnityEngine;
using System.Collections;

public class TowerData
{
    public int boneBuyPrice;
    public int boneSellPrice;
    public int experienceOnHit;

    public TowerData(Tower tower)
    {
        this.boneBuyPrice = tower.boneBuyPrice;
        this.boneSellPrice = tower.boneSellPrice;
        this.experienceOnHit = tower.experienceOnHit;
    }
}
