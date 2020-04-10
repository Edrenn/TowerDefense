using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] GameObject BuyInterface;
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
        if (cg.CanBuy(tower.bonePrice))
        {
            currentTower = tower;
            cg.SpendBones(currentTower.bonePrice);
            SpawnTower();
            BuyInterface.SetActive(false);
        }
    }

    private void SpawnTower()
    {

        currentTower = Instantiate(currentTower, transform.position, Quaternion.identity) as Tower;
        GetComponent<SpriteRenderer>().enabled = false;

    }
}
