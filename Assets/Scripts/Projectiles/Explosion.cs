using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Projectiles
{
    public class Explosion: MonoBehaviour
    {
        [SerializeField] AudioSource audio;
        private void Awake()
        {
            audio.volume = PlayerPrefs.GetFloat(OptionManager.SOUNDVOLUME_KEY);
        }
    }
}
