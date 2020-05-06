using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    [Serializable]
    public class CoreGameData
    {
        public const string DATAKEY = "GameDatas";

        public float killIncomeBonus;
        public int maxBoneUpgrade;
        public int currentBoneUpgradeIndex;

        public int towerDamageBonus;
        public int maxTowerDamageUpgrade;
        public int currentTowerDamageUpgradeIndex;

        public int towerShootSpeedBonus;
        public int maxTowerShootSpeedUpgrade;
        public int currentTowerShootSpeedUpgradeIndex;

        public int upgradePointsAvailable;

    }
}
