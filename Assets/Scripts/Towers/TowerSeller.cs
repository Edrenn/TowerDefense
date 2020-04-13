using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSeller : MonoBehaviour
{
    [SerializeField] private Text priceText;

    public void UpdatePrice(int newPrice)
    {
        priceText.text = newPrice.ToString();
    }
    private void OnMouseDown()
    {
        Tower currentTower = GetComponentInParent<Tower>();
        if (currentTower)
        {
            FindObjectOfType<CoreGame>().AddBones(currentTower.boneSellPrice);
            Destroy(currentTower.gameObject);
        }
    }
}
