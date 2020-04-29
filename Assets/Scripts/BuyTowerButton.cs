using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyTowerButton : MonoBehaviour
{
    private string towerName;
    private int price;
    private Sprite sprite;
    private float towerRange;
    private TowerSpawner parent;

    private void Start()
    {
        parent = GetComponentInParent<TowerSpawner>();
    }
    public void SelectTower()
    {
        Debug.Log("You cliked on : " + gameObject.name);
        parent.TryToBuy(price, towerName);
    }

    public void SetTowerData(string _towerName, int _price, Sprite _sprite, float _towerRange)
    {
        towerName = _towerName;
        price = _price;
        sprite = _sprite;
        towerRange = _towerRange;
        GetComponentInChildren<Text>().text = price.ToString();
        GetComponentInChildren<Image>().sprite = sprite;
    }

    public void SetParent(TowerSpawner _parent)
    {
        parent = _parent;
    }

    public void ShowRange()
    {
        parent.ShowRange(towerRange);
    }

    public void HideRange()
    {
        parent.HideRange();
    }
}
