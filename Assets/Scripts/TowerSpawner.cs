using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] Tower TowerPrefab;
    Tower currentTower;

    private void OnMouseDown()
    {
        TryToBuy();
    }

    private void TryToBuy()
    {
        CoreGame cg = FindObjectOfType<CoreGame>();
        if (cg.CanBuy(TowerPrefab.bonePrice))
        {
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
