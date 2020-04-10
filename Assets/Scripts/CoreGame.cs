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

    [SerializeField] float[] availableGameSpeed = new float[] { 1,2,3 };
    [SerializeField] Text changeSpeedButtonText;
    private int currentGameSpeedIndex = 0;

    private void Awake()
    {
        UpdateGameSpeedText();
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

    public void ChangeGameSpeed()
    {
        currentGameSpeedIndex++;
        if (currentGameSpeedIndex >= availableGameSpeed.Length)
        {
            currentGameSpeedIndex = 0;
        }
        Time.timeScale = availableGameSpeed[currentGameSpeedIndex];
        UpdateGameSpeedText();
    }

    private void UpdateGameSpeedText()
    {
        changeSpeedButtonText.text = "x" + availableGameSpeed[currentGameSpeedIndex].ToString();
    }

}
