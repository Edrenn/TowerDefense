using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    private LevelData selectedLevel;

    public void SetLevelData(LevelData newLvl)
    {
        selectedLevel = newLvl;
        GetComponent<Text>().text = selectedLevel.Index.ToString();
        SetLocked(newLvl.isUnlocked);
    }

    public void LoadLevel()
    {
        DataConveyer dataConveyer = FindObjectOfType<DataConveyer>();
        if (dataConveyer == null)
        {
            GameObject newDataConveyer = new GameObject("DataConveyer");
            newDataConveyer.AddComponent(typeof(DataConveyer));
            dataConveyer = newDataConveyer.GetComponent<DataConveyer>();
        }
        dataConveyer.currentLevelData = selectedLevel;
        FindObjectOfType<LevelLoader>().LoadLevel(selectedLevel.Index);
    }

    public void SetLocked(bool isInteractable)
    {
        GetComponent<Button>().interactable = isInteractable;
    }
}
