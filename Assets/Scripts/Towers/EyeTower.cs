using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Towers
{
    public class EyeTower : MonoBehaviour
    {
        private List<TowerLevel> levels;

        private void Awake()
        {
            Tower currentTower = GetComponent<Tower>();
            if (currentTower)
            {
                currentTower.levels = this.levels;

            }
        }
    }
}
