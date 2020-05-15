using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class BossDeath : MonoBehaviour
    {
        private void Start()
        {
            Time.timeScale = 1;
        }
        private void OnDestroy()
        {
            CoreGame cg = FindObjectOfType<CoreGame>();
            if (cg)
            {
                cg.OnWin();
            }
        }
    }
}
