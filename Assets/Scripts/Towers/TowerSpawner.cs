using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] GameObject BuyInterface;
    [SerializeField] GameObject Btn;

    Tower currentTower;

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

    public  void TryToBuy(Tower tower)
    {
        CoreGame cg = FindObjectOfType<CoreGame>();
        if (cg.CanBuy(tower.boneSellPrice))
        {
            currentTower = tower;
            cg.SpendBones(currentTower.boneBuyPrice);
            SpawnTower();
            BuyInterface.SetActive(false);
        }
    }

    public void SetAvailableTowers(List<Tower> towers)
    {
        foreach (var tower in towers)
        {
            GameObject gameObject = Instantiate(Btn);
            gameObject.GetComponent<BuyTowerButton>().SetTowerData(tower);
            gameObject.transform.SetParent(BuyInterface.transform, false);
        }
    }

    private void SpawnTower()
    {

        currentTower = Instantiate(currentTower, transform.position, Quaternion.identity) as Tower;
        currentTower.parentSpawner = this;
        this.gameObject.SetActive(false);

    }
}
