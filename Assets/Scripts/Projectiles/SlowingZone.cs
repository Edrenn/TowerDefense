﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Projectiles
{
    public class SlowingZone : MonoBehaviour
    {
        [SerializeField] private float slowingCoef;
        [SerializeField] private float slowingDuration;
        List<Attacker> allAttackerInRange;

        private void Awake()
        {
            allAttackerInRange = new List<Attacker>();
        }

        IEnumerator Start()
        {
            yield return new WaitForSeconds(slowingDuration);
            foreach (var att in allAttackerInRange)
            {
                att.ResetSpeed();
            }
            Destroy(gameObject);
        }

        public void SetSlowingCoef(float newSlowCoef)
        {
            slowingCoef = newSlowCoef;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Attacker attacker = collision.GetComponent<Attacker>();
            if (attacker)
            {
                allAttackerInRange.Add(attacker);
                attacker.SetMovementSpeed(attacker.GetMovementSpeed() * slowingCoef);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            Attacker attacker = collision.GetComponent<Attacker>();
            if (attacker)
            {
                allAttackerInRange.Remove(attacker);
                attacker.ResetSpeed();
            }
        }
    }
}