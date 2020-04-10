using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker attacker = collision.GetComponent<Attacker>();
        if (attacker)
        {
            attacker.SetGiveMoney(false);
        }
        Destroy(collision.gameObject);
        GetComponent<Health>().ReduceHealth(1);
    }
}
