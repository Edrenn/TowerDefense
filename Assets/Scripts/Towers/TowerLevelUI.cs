using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerLevelUI : MonoBehaviour
{
    [SerializeField] private Text levelText;
    [SerializeField] private GameObject upgradeReady;

    public void UpdateLevel(string newLevel)
    {
        levelText.text = newLevel;
    }

    public void SetUpgradeVisibility(bool isVisible)
    {
        upgradeReady.SetActive(isVisible);
    }

}
