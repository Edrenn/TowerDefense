using Assets.Scripts;
using Assets.Scripts.enums;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CoreGame : MonoBehaviour
{
    [SerializeField] Canvas mainCanvas;
    public CoreGameData datas;
    public int boneAmount;
    [SerializeField] Text boneCountText;
    public int currentLevel;

    public int castleCurrentHP;
    [SerializeField] Text castleHPText;
    [SerializeField] GameObject loseHPAnimation;
    [SerializeField] GameObject victoryScreen;
    bool isVictoryScreenOn = false;
    [SerializeField] GameObject defeatScreen;

    [SerializeField] float[] availableGameSpeed = new float[] { 1,2,3 };
    [SerializeField] Text changeSpeedButtonText;
    private int currentGameSpeedIndex = 0;

    List<Spawner> allSpawners;
    GameObject spawnerParent;


    public const string ATTACKER_PARENT_GAMEOBJECT = "ATTACKERPARENT";
    [SerializeField] public List<Attacker> allAvailableAttackers;
    private Dictionary<AttackerEnum, Attacker> allAvailableAttackersDictionary;


    // TEMP
    public Tower towerPrefab;

    private void Awake()
    {
        datas = SaveSystem.LoadGeneric<CoreGameData>(CoreGameData.DATAKEY);
        UpdateGameSpeedText();
        UpdateBoneText();
        UpdateLifeText();
        victoryScreen.SetActive(false);
        defeatScreen.SetActive(false);

        allAvailableAttackersDictionary = new Dictionary<AttackerEnum, Attacker>();
        foreach (var att in allAvailableAttackers)
        {
            allAvailableAttackersDictionary.Add(att.enumName, att);
        }

        List<Tower> towers = new List<Tower>
        {
            towerPrefab,
            towerPrefab,
            towerPrefab
        };

        var towerSpawners = FindObjectsOfType<TowerSpawner>();
        foreach (var tower in towerSpawners)
        {
            tower.SetAvailableTowers(towers);
        }
    }

    private void Start()
    {
        allSpawners = FindObjectsOfType<Spawner>().ToList();
        spawnerParent = GameObject.Find(ATTACKER_PARENT_GAMEOBJECT);
        if (!spawnerParent)
        {
            spawnerParent = new GameObject(ATTACKER_PARENT_GAMEOBJECT);
        }
    }

    private void Update()
    {
        if (allSpawners != null && allSpawners.Count <= 0 && spawnerParent.transform.childCount == 0 && !isVictoryScreenOn)
        {
            Debug.Log("Show Victory Screen");
            isVictoryScreenOn = true;
            victoryScreen.SetActive(true);
            StartCoroutine(ChangeToVictoryScreen());
            this.datas.lastUnlockLevel = currentLevel + 1;
        }
    }

    IEnumerator ChangeToVictoryScreen()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(3);
        FindObjectOfType<LevelLoader>().LoadVictoryScreen();

    }

    #region Bones
    public void AddBones(int amount)
    {
        boneAmount += amount;
        UpdateBoneText();
    }

    public void AddBonesByKill(int amount)
    {
        boneAmount += Mathf.RoundToInt(amount * (1 + (datas.killIncomeBonus/100)));
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
            defeatScreen.SetActive(true);
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

    public Attacker FindAttacker(AttackerEnum attackerName)
    {
        if (allAvailableAttackersDictionary.ContainsKey(attackerName))
        {
            return allAvailableAttackersDictionary[attackerName];
        }
        else
            return null;
    }
}
