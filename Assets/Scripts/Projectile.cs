using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Attacker target;
    [SerializeField] float speed = 5f;
    private int damage = 1;

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
            attacker.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
