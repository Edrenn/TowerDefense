using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUpgrade : MonoBehaviour
{
    [SerializeField] private Text labelText;
    [SerializeField] private Text priceText;
    private bool maxed = false;

    public void UpdatePrice(int newPrice)
    {
        priceText.text = newPrice.ToString();
    }

    public void UpgradeMaxedLevel()
    {
        labelText.text = "MAXED";
        priceText.text = "";
        maxed = true;
    }

    private void OnMouseDown()
    {
        if (!maxed)
        {
            Tower currentTower = GetComponentInParent<Tower>();
            if (currentTower)
            {
                currentTower.TryToUpgrade();
            }
        }
    }
}
