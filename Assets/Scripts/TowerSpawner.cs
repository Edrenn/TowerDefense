using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] GameObject TowerPrefab;
    GameObject currentTower;

    private void OnMouseDown()
    {
        SpawnTower();
    }

    private void SpawnTower()
    {
        currentTower = Instantiate(TowerPrefab, transform.position, Quaternion.identity) as GameObject;
        GetComponent<SpriteRenderer>().enabled = false;

    }
}
