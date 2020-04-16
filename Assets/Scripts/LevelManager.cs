using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private CoreGameData data;
    public int lastLevelUnlocked;

    private void Awake()
    {
        data = SaveSystem.LoadGame();
        if (data != null)
        {
            foreach (LevelButton but in FindObjectsOfType<LevelButton>())
            {
                if (but.levelIndex > data.lastUnlockLevel)
                {
                    but.SetInteractable(false);
                }
            }
        }
        else
        {
            Debug.LogError("Can't load game datas");
        }
    }


    public void Save()
    {
        data.lastUnlockLevel = lastLevelUnlocked;
        SaveSystem.SaveGame(data);
    }

    public void ResetData()
    {
        lastLevelUnlocked = 1;
        Save();
        data.lastUnlockLevel = 1;
        foreach (LevelButton but in FindObjectsOfType<LevelButton>())
        {
            if (but.levelIndex > data.lastUnlockLevel)
            {
                but.SetInteractable(false);
            }
        }
    }
}
