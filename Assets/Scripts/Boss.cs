using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Boss : Attacker
    {
        protected override void Die()
        {
            Time.timeScale = 1;
            GameObject deathAnim = Instantiate(DeathAnimation, transform.position, Quaternion.identity) as GameObject;
            Destroy(deathAnim, timeBeforeDestroyDeathAnim);
            Destroy(this.gameObject);
        }
    }
}
