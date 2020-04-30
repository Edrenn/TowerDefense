﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        public Tower parent;
        [SerializeField] protected float speed = 5f;

        protected Attacker target;
        protected int damage = 1;

        public void SetTarget(Attacker newTarget)
        {
            target = newTarget;
        }

        public void SetDamage(int amount)
        {
            damage = amount;
        }

        private void Update()
        {
            if (target)
            {
                Vector3 direction = (target.transform.position - transform.position).normalized;
                transform.Translate(direction * speed * Time.deltaTime);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Attacker attacker = collision.GetComponent<Attacker>();
            if (attacker && attacker == target)
            {
                bool died = attacker.TakeDamage(damage);
                if (died)
                {
                    parent.KillAnAttacker(attacker);
                }
                else
                    parent.HitAnAttacker();
                Destroy(this.gameObject);
            }
        }
    }
}