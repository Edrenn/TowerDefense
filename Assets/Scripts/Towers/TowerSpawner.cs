using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] GameObject BuyInterface;
    [SerializeField] GameObject Btn;

    private void Awake()
    {
        BuyInterface.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (BuyInterface.activeSelf)
        {
            BuyInterface.SetActive(false);
        }
        else
            BuyInterface.SetActive(true);
    }

    public void TryToBuy(int price, string towerName)
    {
        CoreGame cg = FindObjectOfType<CoreGame>();
        if (cg.CanBuy(price))
        {
            Tower towerToSpawn = FindObjectOfType<CoreGame>().FindTowerByName(towerName);
            cg.SpendBones(price);
            SpawnTower(towerToSpawn);
            BuyInterface.SetActive(false);
        }
    }

    public void SetAvailableTowers(List<Tower> towers)
    {
        foreach (var tower in towers)
        {
            GameObject gameObject = Instantiate(Btn);
            gameObject.GetComponent<BuyTowerButton>().SetTowerData(tower.name,tower.boneBuyPrice, tower.towerSprite);
            gameObject.transform.SetParent(BuyInterface.transform, false);
        }
    }

    private void SpawnTower(Tower towerToSpawn)
    {
        Tower currentTower = Instantiate(towerToSpawn, transform.position, Quaternion.identity) as Tower;
        currentTower.parentSpawner = this;
        this.gameObject.SetActive(false);

    }
}
