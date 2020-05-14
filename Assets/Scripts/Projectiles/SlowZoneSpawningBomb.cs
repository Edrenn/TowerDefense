using Assets.Scripts.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Projectiles
{
    public class SlowZoneSpawningBomb : Projectile
    {
        Vector3 targetPosition;
        [SerializeField] GameObject slowZonePrefab;
        public float slowCoef;
        private Tower parentTower;
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
                SpawnSlowZone();
            }
        }

        public void SetParentTower(Tower _parentTower)
        {
            parentTower = _parentTower;
        }

        private void SpawnSlowZone()
        {
            GameObject slowZone = Instantiate(slowZonePrefab, transform.position, Quaternion.identity);
            SlowingZone slowingZone = slowZone.GetComponent<SlowingZone>();
            slowingZone.SetParentTower(parentTower);
            slowingZone.SetSlowingCoef(slowCoef);
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Override to avoid destruction of projectile on enemy hit
        }
    }


}
