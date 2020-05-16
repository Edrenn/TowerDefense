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
                newLevelUI.GetComponentInChildren<LevelButton>().SetLevelData(lvl);
                if (lvl.currentScore == 0)
                    newLevelUI.GetComponentInChildren<ScoreManager>().gameObject.SetActive(false);
                else
                {
                    newLevelUI.GetComponentInChildren<ScoreManager>().gameObject.SetActive(true);
                    newLevelUI.GetComponentInChildren<ScoreManager>().SetSkullScore(lvl.currentScore);
                }
                newLevelUI.transform.SetParent(hlg.transform);
            }
        }

    }
}
