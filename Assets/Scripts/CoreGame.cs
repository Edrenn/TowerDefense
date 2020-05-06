using Assets.Scripts;
using Assets.Scripts.enums;
using Assets.Scripts.Extension;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CoreGame : MonoBehaviour
{
    [SerializeField] Canvas mainCanvas;
    public CoreGameData datas;
    // bones
    public int boneAmount;
    [SerializeField] Text boneCountText;
    public int currentLevel;
    // castle hp
    [SerializeField] Text castleHPText;
    public int castleCurrentHP;

    // Win lose Screen
    [SerializeField] GameObject loseHPAnimation;
    [SerializeField] GameObject victoryScreen;
    bool isVictoryScreenOn = false;
    [SerializeField] GameObject defeatScreen;

    [SerializeField] GameObject pauseScreen;

    // Speed
    [SerializeField] float[] availableGameSpeed = new float[] { 1, 2, 3 };
    [SerializeField] Text changeSpeedButtonText;
    private int currentGameSpeedIndex = 0;
    private bool isGamePaused = false;
    // Towers
    public Dictionary<string,Tower> availableTowers;

    List<Spawner> allSpawners;
    GameObject spawnerParent;


    public const string ATTACKER_PARENT_GAMEOBJECT = "ATTACKERPARENT";
    [SerializeField] public List<Attacker> allAvailableAttackers;
    private Dictionary<AttackerEnum, Attacker> allAvailableAttackersDictionary;


    // TEMP
    public Tower towerPrefab;

    private void Awake()
    {
        //datas = FindObjectOfType<DataConveyer>().gameDatas;
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
        InitializeTowers();
    }

    private void Start()
    {
        allSpawners = FindObjectsOfType<Spawner>().ToList();
        spawnerParent = GameObject.Find(ATTACKER_PARENT_GAMEOBJECT);
        if (!spawnerParent)
        {
            spawnerParent = new GameObject(ATTACKER_PARENT_GAMEOBJECT);
        }
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        if (allSpawners != null && allSpawners.Count <= 0 && spawnerParent.transform.childCount == 0 && !isVictoryScreenOn)
        {
            OnWin();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGamePaused)
            {
                SetPauseOn();
            }
            else
            {
                SetPauseOff();
            }

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
        boneAmount += amount.AddPercentageCoef(datas.killIncomeBonus);
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

    #region Towers
    private void InitializeTowers()
    {
        availableTowers = new Dictionary<string, Tower>();
        //List<TowerData> towerDatas = FindObjectOfType<DataConveyer>().allTowerDatas;
        List<TowerData> towerDatas = SaveSystem.LoadGeneric<List<TowerData>>(TowerData.DATAKEY);

        if (towerDatas != null && towerDatas.Count > 0)
        {
            foreach (var towerData in towerDatas)
            {
                Tower newTower = (Tower)Resources.Load("TowersPrefab/"+towerData.towerName, typeof(Tower));
                newTower.SetTowerData(towerData);
                newTower.SetTowerBonus(towerData.damage.AddPercentageCoef(datas.towerDamageBonus), towerData.shotSpeed.AddPercentageCoef(datas.towerDamageBonus));
                availableTowers.Add(towerData.towerName, newTower);
            }
        }

        var towerSpawners = FindObjectsOfType<TowerSpawner>();
        foreach (var tower in towerSpawners)
        {
            tower.SetAvailableTowers(availableTowers.Values.ToList());
        }
    }
    public Tower FindTowerByName(string towerName)
    {
        if (availableTowers.ContainsKey(towerName))
        {
            return availableTowers[towerName];
        }

        return null;
    }
    #endregion

    #region Pause
    private void SetPauseOn()
    {
        isGamePaused = true;
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    public void SetPauseOff()
    {
        isGamePaused = false;
        Time.timeScale = availableGameSpeed[currentGameSpeedIndex];
        pauseScreen.SetActive(false);
    }
    #endregion

    public void OnWin()
    {
        Debug.Log("Show Victory Screen");
        isVictoryScreenOn = true;
        victoryScreen.SetActive(true);
        StartCoroutine(ChangeToVictoryScreen());
    }

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
