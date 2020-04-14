using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CoreGame : MonoBehaviour
{
    [SerializeField] Canvas mainCanvas;

    public int boneAmount;
    [SerializeField] Text boneCountText;

    public int castleCurrentHP;
    [SerializeField] Text castleHPText;
    [SerializeField] GameObject loseHPAnimation;

    [SerializeField] float[] availableGameSpeed = new float[] { 1,2,3 };
    [SerializeField] Text changeSpeedButtonText;
    private int currentGameSpeedIndex = 0;

    List<Spawner> allSpawners;
    GameObject spawnerParent;

    private void Awake()
    {
        UpdateGameSpeedText();
        UpdateBoneText();
        UpdateLifeText();
    }

    private void Start()
    {
        allSpawners = FindObjectsOfType<Spawner>().ToList();
        spawnerParent = GameObject.Find(LevelData.ATTACKER_PARENT_GAMEOBJECT);
        if (!spawnerParent)
        {
            spawnerParent = new GameObject(LevelData.ATTACKER_PARENT_GAMEOBJECT);
        }
    }

    private void Update()
    {
        if (allSpawners != null && allSpawners.Count <= 0 && spawnerParent.transform.childCount == 0)
        {
            Debug.Log("WINNED");
        }
    }

    #region Bones
    public void AddBones(int amount)
    {
        boneAmount += amount;
        UpdateBoneText();
    }

    public bool SpendBones(int amount)
    {
        if (CanBuy(amount))
        {
            boneAmount -= amount;
            UpdateBoneText();
            return true;
        }

        return false;
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
        GameObject loseHPAnim = Instantiate(loseHPAnimation, castleHPText.rectTransform.position, Quaternion.identity) as GameObject;
        loseHPAnim.transform.SetParent(castleHPText.rectTransform, false);
        Destroy(loseHPAnim, 1f);
        if (castleCurrentHP <= 0)
        {
            Debug.Log("LOSED");
            Time.timeScale = 0;
        }
    }

    private void UpdateLifeText()
    {
        castleHPText.text = castleCurrentHP.ToString();
    }
    #endregion

    #region GameSpeed
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
    #endregion

    public void SpawnerFinishedCall(Spawner spawner)
    {
        if (allSpawners == null)
        {
            allSpawners = FindObjectsOfType<Spawner>().ToList();
        }
        allSpawners.Remove(spawner);
    }

    public void SpawnNextWave()
    {

    }
}
