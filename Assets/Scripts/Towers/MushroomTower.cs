using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Towers
{
    public class MushroomTower : MonoBehaviour
    {
        private List<TowerLevel> levels;

        private void Awake()
        {
            levels = new List<TowerLevel>()
            {
                new TowerLevel(40,1,50),
                new TowerLevel(60,1,70),
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
