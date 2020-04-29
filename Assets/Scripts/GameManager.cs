using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
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

}
