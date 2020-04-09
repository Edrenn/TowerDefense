using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] GameObject BuyInterface;
    [SerializeField] Tower TowerPrefab;
    Tower currentTower;

    private void OnMouseDown()
    {
        if (BuyInterface.activeSelf)
        {
            BuyInterface.SetActive(false);
        }
        else
            BuyInterface.SetActive(true);
        //TryToBuy();
    }

    public void Test()
    {
        Debug.Log("TEST");
    }

    public  void TryToBuy(Tower tower)
    {
        Debug.Log("Bonjour");
        CoreGame cg = FindObjectOfType<CoreGame>();
        if (cg.CanBuy(tower.bonePrice))
        {
            currentTower = tower;
            Debug.Log("Selected tower : " + currentTower.name);
            cg.SpendBones(TowerPrefab.bonePrice);
            SpawnTower();
        }
    }

    private void SpawnTower()
    {

        currentTower = Instantiate(TowerPrefab, transform.position, Quaternion.identity) as Tower;
        GetComponent<SpriteRenderer>().enabled = false;

    }
}
