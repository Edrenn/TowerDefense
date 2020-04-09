using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreGame : MonoBehaviour
{
    public int boneAmount;
    [SerializeField] Text boneCountText;

    private void Awake()
    {
        UpdateBoneText();
    }

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

}
