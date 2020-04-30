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
            levels = new List<TowerLevel>()
            {
                new TowerLevel(40,1,80),
                new TowerLevel(60,1,100),
                new TowerLevel()
            };
            Tower currentTower = GetComponent<Tower>();
            if (currentTower)
            {
                currentTower.levels = this.levels;

            }
        }
    }
}
