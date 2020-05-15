using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class DataConveyer : MonoBehaviour
    {
        public LevelData currentLevelData { get; set; }
        public CoreGameData gameDatas { get; set; }

        /// <summary>
        /// All levels with their id as key
        /// </summary>
        public Dictionary<int,LevelData> allLevels { get; set; }

        public List<TowerData> allTowerDatas { get; set; }

        public int lastLevelRemainingHP { get; set; }

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
