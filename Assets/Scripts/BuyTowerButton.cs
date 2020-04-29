using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyTowerButton : MonoBehaviour
{
    private string towerName;
    private int price;
    private Sprite sprite;
    public void SelectTower()
    {
        Debug.Log("You cliked on : " + gameObject.name);
        TowerSpawner ts = GetComponentInParent<TowerSpawner>();
        if (ts)
        {
            ts.TryToBuy(price, towerName);
        }
    }

    public void SetTowerData(string _towerName, int _price, Sprite _sprite)
    {
        towerName = _towerName;
        price = _price;
        sprite = _sprite;
        GetComponentInChildren<Text>().text = price.ToString();
        GetComponentInChildren<Image>().sprite = sprite;
    }
}
