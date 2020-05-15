﻿using Assets.Scripts;
using Assets.Scripts.enums;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        TestIfFirstLaunch();
        DataConveyer dataConveyer = FindObjectOfType<DataConveyer>();
        dataConveyer.gameDatas = SaveSystem.LoadGeneric<CoreGameData>(CoreGameData.DATAKEY);
        List<LevelData> levelDatas = SaveSystem.LoadGeneric<List<LevelData>>(LevelData.DATAKEY);
        dataConveyer.allLevels = new Dictionary<int, LevelData>();
        foreach (var lvl in levelDatas)
        {
            dataConveyer.allLevels.Add(lvl.Index, lvl);
        }

        dataConveyer.allTowerDatas = SaveSystem.LoadGeneric<List<TowerData>>(TowerData.DATAKEY);
    }

    private void TestIfFirstLaunch()
    {
        string path = Application.persistentDataPath + "/" + CoreGameData.DATAKEY;
        if (!File.Exists(path))
        {
            CoreGameData coreGameData = new CoreGameData();
            SaveSystem.SaveGeneric<CoreGameData>(coreGameData, CoreGameData.DATAKEY);
        }

        path = Application.persistentDataPath + "/" + LevelData.DATAKEY;
        if (!File.Exists(path))
        {
            List<LevelData> levels = new List<LevelData>();
            levels.Add(new LevelData()
            {
                currentScore = 0,
                Index = 1,
                isUnlocked = true,
                isBossLevel = true,
                Waves = new List<Wave>
                {
                    new Wave() { enemyType = AttackerEnum.Farmer, nbEnemy = 1 }
                    //,new Wave() { enemyType = AttackerEnum.Farmer, nbEnemy = 5 }
                    //,new Wave() { enemyType = AttackerEnum.Farmer, nbEnemy = 10 }
                    //,new Wave() { enemyType = AttackerEnum.Ranger, nbEnemy = 15 }
                },
                bossWave = new BossWave()
                {
                    ennemies = new List<Wave>
                        {
                        new Wave() { enemyType = AttackerEnum.Knight, nbEnemy = 3 }
                        ,new Wave() { enemyType = AttackerEnum.Warchief, nbEnemy = 1 }
                        ,new Wave() { enemyType = AttackerEnum.Knight, nbEnemy = 3 }
                        ,new Wave() { enemyType = AttackerEnum.Knight, nbEnemy = 3 }
                        }
                }
            });
            levels.Add(new LevelData()
            {
                currentScore = 0,
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
                currentScore = 0,
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

            SaveSystem.SaveGeneric<List<LevelData>>(levels, LevelData.DATAKEY);
        }


        path = Application.persistentDataPath + "/" + TowerData.DATAKEY;
        if (!File.Exists(path))
        {
            List<TowerData> towerDatas = new List<TowerData>();
            towerDatas.Add(new TowerData("GoblinTower", 50, 2, new List<TowerLevel>() { new TowerLevel(10, 0, 50) }, 2, 10, 3));
            towerDatas.Add(new TowerData("EyeTower", 50, 2, new List<TowerLevel>() { new TowerLevel(10, 0, 50) }, 3, 50, 1));
            towerDatas.Add(new TowerData("MushroomTower", 50, 2, new List<TowerLevel>() { new TowerLevel(10, 0, 50) }, 3, 0, .6f));
            SaveSystem.SaveGeneric(towerDatas, TowerData.DATAKEY);
        }

    }

}
