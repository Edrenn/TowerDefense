using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class WinManager : MonoBehaviour
    {
        [SerializeField] Text levelNameText;
        [SerializeField] Image[] skullScoreTab;
        

        private void Awake()
        {
            DataConveyer dataConveyer = FindObjectOfType<DataConveyer>();
            // We test if there is a level to unlock (currentLevel.Index + 1)
            if (dataConveyer.allLevels.ContainsKey(dataConveyer.currentLevelData.Index + 1))
            {
                dataConveyer.allLevels[dataConveyer.currentLevelData.Index + 1].isUnlocked = true;
            }
            if (dataConveyer.currentLevelData.upgradePointAvailable == true)
            {
                dataConveyer.gameDatas.upgradePointsAvailable += 1;
                dataConveyer.currentLevelData.upgradePointAvailable = false;
            }

            levelNameText.text = dataConveyer.currentLevelData.Index.ToString();
            SetSkullScore(dataConveyer.currentLevelData.currentScore);

            // Add Score

            SaveSystem.SaveGeneric<List<LevelData>>(dataConveyer.allLevels.Values.ToList(),LevelData.DATAKEY);

            if (!dataConveyer.allLevels.ContainsKey(dataConveyer.currentLevelData.Index + 1))
            {
                FindObjectOfType<LevelLoader>().LoadEndGameScene();
            }
        }

        private void SetSkullScore(int score)
        {
            for (int i = 0; i < score; i++)
            {
                skullScoreTab[i].color = Color.white;
            }
        }

    }
}
