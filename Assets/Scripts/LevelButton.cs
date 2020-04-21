using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int levelIndex;

    public void SetLevelData(LevelData newLvl)
    {
        levelIndex = newLvl.Index;
        GetComponent<Text>().text = levelIndex.ToString();
        SetLocked(newLvl.isUnlocked);
    }

    public void LoadLevel()
    {
        FindObjectOfType<LevelLoader>().LoadLevel(levelIndex);
    }

    public void SetLocked(bool isInteractable)
    {
        GetComponent<Button>().interactable = isInteractable;
    }
}
