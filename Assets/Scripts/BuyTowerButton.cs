using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyTowerButton : MonoBehaviour
{
    [SerializeField] Tower tower;

    public void SelectTower()
    {
        Debug.Log("You cliked on : " + gameObject.name);
        TowerSpawner ts = GetComponentInParent<TowerSpawner>();
        if (ts)
        {
            ts.TryToBuy(tower);
        }
    }

    public void SetTowerData(Tower newTower)
    {
        tower = newTower;
        GetComponentInChildren<Text>().text = tower.boneBuyPrice.ToString();
        GetComponentInChildren<Image>().sprite = tower.towerSprite;
    }
}
