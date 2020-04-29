using Assets.Scripts;
using Assets.Scripts.enums;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private CoreGameData data;
    private List<LevelData> allLevels;
    [SerializeField] private GameObject levelUIPrefab;
    public int lastLevelUnlocked;

    private void Awake()
    {
        Debug.Log(Application.persistentDataPath);
        HorizontalLayoutGroup hlg = FindObjectOfType<HorizontalLayoutGroup>();
        allLevels = FindObjectOfType<DataConveyer>().allLevels.Values.ToList();
        if (allLevels != null)
        {
            foreach (var lvl in allLevels)
            {
                GameObject newLevelUI = Instantiate(levelUIPrefab);
                newLevelUI.GetComponent<LevelButton>().SetLevelData(lvl);
                newLevelUI.transform.SetParent(hlg.transform);
            }
        }

    }

    public void Save()
    {
        //CoreGameData coreGameData = new CoreGameData();
        //coreGameData.lastUnlockLevel = 1;
        //SaveSystem.SaveGeneric<CoreGameData>(coreGameData, CoreGameData.DATAKEY);

        //List<TowerData> towerDatas = new List<TowerData>();
        //towerDatas.Add(new TowerData("GoblinTower", 50, 2, new List<TowerLevel>() { new TowerLevel(10, 0, 50) }, 2, 10, 3));
        //SaveSystem.SaveGeneric(towerDatas, TowerData.DATAKEY);

        /*
        List<LevelData> levels = new List<LevelData>();
        levels.Add(new LevelData()
        {
            currentStars = 0,
            Index = 1,
            isUnlocked = true,
            Waves = new List<Wave>
            {
                new Wave() { enemyType = AttackerEnum.Knight, nbEnemy = 5 },
                new Wave() { enemyType = AttackerEnum.Ranger, nbEnemy = 5 },
                new Wave() { enemyType = AttackerEnum.Knight, nbEnemy = 10 },
                new Wave() { enemyType = AttackerEnum.Ranger, nbEnemy = 15 }
            }
        });
        levels.Add(new LevelData()
        {
            currentStars = 0,
            Index = 2,
            isUnlocked = false,
            Waves = new List<Wave>
            {
                new Wave() { enemyType = AttackerEnum.Knight, nbEnemy = 7 },
                new Wave() { enemyType = AttackerEnum.Ranger, nbEnemy = 10 },
                new Wave() { enemyType = AttackerEnum.Knight, nbEnemy = 13 },
                new Wave() { enemyType = AttackerEnum.Ranger, nbEnemy = 20 }
            }

        });
        levels.Add(new LevelData()
        {
            currentStars = 0,
            Index = 3,
            isUnlocked = false,
            Waves = new List<Wave>
            {
                new Wave() { enemyType = AttackerEnum.Knight, nbEnemy = 15 },
            new Wave() { enemyType = AttackerEnum.Ranger, nbEnemy = 15 },
            new Wave() { enemyType = AttackerEnum.Knight, nbEnemy = 20 },
            new Wave() { enemyType = AttackerEnum.Ranger, nbEnemy = 20 }
            }
        });
        
        SaveSystem.SaveGeneric<List<LevelData>>(levels,LevelData.DATAKEY);*/
    }

    public void ResetData()
    {
       
    }
}
