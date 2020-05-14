using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Towers
{
    public class UpgradeParameters
    {
        public int damageIncrease;
        public float shootSpeedIncrease;
        public float slowEffectIncrease;

        public UpgradeParameters(int damageIncrease, float shootSpeedIncrease, float slowEffectIncrease)
        {
            this.damageIncrease = damageIncrease;
            this.shootSpeedIncrease = shootSpeedIncrease;
            this.slowEffectIncrease = slowEffectIncrease;
        }
    }
}
