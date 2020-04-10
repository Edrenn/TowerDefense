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
            FindObjectOfType<CoreGame>().LoseHP(1);
        }
        Destroy(collision.gameObject);
    }
}
