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

        [SerializeField] GameObject nextSkullGO;
        [SerializeField] Text nextSkullText;

        [SerializeField] Text remainingHPText;


        private void Awake()
        {
            nextSkullGO.SetActive(false);
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
            remainingHPText.text = dataConveyer.lastLevelRemainingHP.ToString();
            // Add Score
            SetSkullScore(dataConveyer.currentLevelData.currentScore);
            if (dataConveyer.currentLevelData.currentScore < 3)
            {
                SetNextSkullNeed(dataConveyer.currentLevelData.currentScore);
            }


            SaveSystem.SaveGeneric<List<LevelData>>(dataConveyer.allLevels.Values.ToList(),LevelData.DATAKEY);
        }

        private void SetSkullScore(int score)
        {
            for (int i = 0; i < score; i++)
            {
                skullScoreTab[i].color = Color.white;
            }
        }

        private void SetNextSkullNeed(int score)
        {
            if (score == 2)
            {
                nextSkullText.text = "10 HP";
            }
            else if (score == 1)
            {
                nextSkullText.text = "5 HP";
            }
            nextSkullGO.SetActive(true);
        }

        public void ReturnToMenu()
        {
            DataConveyer dataConveyer = FindObjectOfType<DataConveyer>();
            if (dataConveyer.allLevels.Count == dataConveyer.currentLevelData.Index)
            {
                FindObjectOfType<MusicManager>().LaunchEndSong();
                FindObjectOfType<LevelLoader>().LoadEndGameScene();
            }
            else
            {
                FindObjectOfType<MusicManager>().LaunchMenuSong();
                FindObjectOfType<LevelLoader>().LoadLevelSelection();
            }
        }
    }
}
