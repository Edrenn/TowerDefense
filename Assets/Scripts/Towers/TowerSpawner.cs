using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] GameObject BuyInterface;
    [SerializeField] GameObject Btn;
    [SerializeField] Image RangeImg;

    private void Awake()
    {
        BuyInterface.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (BuyInterface.activeSelf)
        {
            HideInterface();
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
            gameObject.GetComponent<BuyTowerButton>().SetTowerData(tower.towerName,tower.boneBuyPrice, tower.towerSprite, tower.range);
            //gameObject.GetComponent<BuyTowerButton>().SetParent(this);
            gameObject.transform.SetParent(BuyInterface.transform, false);
        }
    }

    private void SpawnTower(Tower towerToSpawn)
    {
        Tower currentTower = Instantiate(towerToSpawn, transform.position, Quaternion.identity) as Tower;
        currentTower.parentSpawner = this;
        this.gameObject.SetActive(false);

    }

    public void ShowRange(float range)
    {
        var newRange = new Vector2(20 * range, 20 * range);
        RangeImg.GetComponent<RectTransform>().sizeDelta = new Vector2(20 * range, 20 * range);
        RangeImg.gameObject.SetActive(true);
    }

    public void HideRange()
    {
        RangeImg.gameObject.SetActive(false);
    }

    public void HideInterface()
    {
        BuyInterface.SetActive(false);
    }
}
