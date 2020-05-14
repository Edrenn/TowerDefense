using Assets.Scripts.Projectiles;
using Assets.Scripts.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class SlowingShooter : Shooter
    {
        public float slowValue;
        private Tower parentTower;

        private void Awake()
        {
            parentTower = GetComponentInParent<Tower>();
        }

        new public void Fire()
        {
            if (currentTarget)
            {
                Projectile proj = Instantiate(projectile, transform.position, Quaternion.identity);
                proj.SetTarget(currentTarget);
                proj.parent = parent;
                SlowZoneSpawningBomb slowBomb = proj.GetComponent<SlowZoneSpawningBomb>();
                slowBomb.SetParentTower(parentTower);
                slowBomb.slowCoef = (100 - slowValue) / 100;

                if (!IsTargetInSight())
                {
                    GetComponent<Animator>().SetBool("isTargetInSight", false);
                }
            }
            else
            {
                GetComponent<Animator>().SetBool("isTargetInSight", false);
            }
        }

        new public void Upgrade(UpgradeParameters upgradeParameters)
        {
            this.slowValue += upgradeParameters.slowEffectIncrease;
        }
    }

}
