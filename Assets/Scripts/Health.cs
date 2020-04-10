using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 4;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void ReduceHealth(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
