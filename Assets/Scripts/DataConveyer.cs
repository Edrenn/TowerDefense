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

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
