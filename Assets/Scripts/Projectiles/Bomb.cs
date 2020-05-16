using Assets.Scripts.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Projectiles
{
    public class Bomb : Projectile
    {
        Vector3 targetPosition;
        List<Attacker> allAttackerInRange;
        [SerializeField] private GameObject explosionAnim;
        private bool exploding;
        [SerializeField] private AudioSource audioSource;
        public void SetShootVolume(float _volume)
        {
            audioSource.volume = _volume;
        }

        private void Awake()
        {
            allAttackerInRange = new List<Attacker>();
        }

        private void Start()
        {
            targetPosition = base.target.transform.position;
        }

        private void Update()
        {
            Vector3 direction = (targetPosition - transform.position);
            transform.Translate(direction * speed * Time.deltaTime);
            if (transform.position.PreciseEquals(targetPosition))
            {
                Explode();
            }
        }

        private void Explode()
        {
            exploding = true;
            GameObject explosion = Instantiate(explosionAnim, transform.position, Quaternion.identity) as GameObject;
            Destroy(explosion, 0.6f);
            foreach (var attacker in allAttackerInRange)
            {
                if (attacker != null)
                {
                    bool died = attacker.TakeDamage(damage);
                    if (died)
                    {
                        parent.KillAnAttacker(attacker);
                    }
                    else
                        parent.HitAnAttacker();
                }
            }
            Destroy(this.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Attacker attacker = collision.GetComponent<Attacker>();
            if (attacker)
                allAttackerInRange.Add(attacker);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!exploding)
            {
                Attacker attacker = collision.GetComponent<Attacker>();
                if (attacker)
                    allAttackerInRange.Remove(attacker);
            }
        }
    }
}
