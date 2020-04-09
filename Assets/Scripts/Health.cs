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
        Debug.Log(gameObject.name + " take " + amount + " damages.");
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log(gameObject.name + " is ded");
        }
    }

}
