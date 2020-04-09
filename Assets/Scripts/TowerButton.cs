using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    [SerializeField] Tower tower;

    private void OnMouseDown()
    {
        SelectTower();
    }

    public void SelectTower()
    {
        Debug.Log("You cliked on : " + gameObject.name);
        //TowerSpawner ts = GetComponentInParent<TowerSpawner>();
        //if (ts)
        //{
        //    ts.TryToBuy(tower);
        //}
    }
}
