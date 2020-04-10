using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreGame : MonoBehaviour
{
    public int boneAmount;
    [SerializeField] Text boneCountText;

    public int castleCurrentHP;
    [SerializeField] Text castleHPText;

    private void Awake()
    {
        UpdateBoneText();
        UpdateLifeText();
    }

    #region Bones
    public void AddBones(int amount)
    {
        boneAmount += amount;
        UpdateBoneText();
    }

    public void SpendBones(int amount)
    {
        if (CanBuy(amount))
        {
            boneAmount -= amount;
            UpdateBoneText();
        }
    }

    public bool CanBuy(int amount)
    {
        return amount <= boneAmount;
    }

    private void UpdateBoneText()
    {
        boneCountText.text = boneAmount.ToString();
    }
    #endregion

    #region Castle
    public void LoseHP(int amount)
    {
        castleCurrentHP -= amount;
        UpdateLifeText();
    }

    private void UpdateLifeText()
    {
        castleHPText.text = castleCurrentHP.ToString();
    }
    #endregion

}
