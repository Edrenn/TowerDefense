using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour
{
    [SerializeField] Tower tower;

    private void Awake()
    {
        GetComponentInChildren<Text>().text = tower.bonePrice.ToString();
        GetComponentInChildren<SpriteRenderer>().sprite = tower.towerSprite;
    }

    private void OnMouseDown()
    {
        SelectTower();
    }

    public void SelectTower()
    {
        Debug.Log("You cliked on : " + gameObject.name);
        TowerSpawner ts = GetComponentInParent<TowerSpawner>();
        if (ts)
        {
            ts.TryToBuy(tower);
        }
    }
}
