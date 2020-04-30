using Assets.Scripts.enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attacker : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 4;
    [SerializeField] int boneValue = 10;
    public int experienceValue = 10;

    public AttackerEnum enumName;
    Vector2 currentDirection = Vector2.down;
    [SerializeField] float currentSpeed = 1f;
    [SerializeField] float maxSpeed = 1f;
    [SerializeField] private GameObject DeathAnimation;
    [SerializeField] private Slider HealthBar;

    private void Awake()
    {
        currentHealth = maxHealth;
        HealthBar.maxValue = maxHealth;
        maxSpeed = currentSpeed;
        UpdateHealthBar();
    }
    public void ResetSpeed()
    {
        currentSpeed = maxSpeed;
    }

    public void SetMovementSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
    }

    public float GetMovementSpeed()
    {
        return currentSpeed;
    }


    private void UpdateHealthBar()
    {
        HealthBar.value = currentHealth <= 0 ? 0 : currentHealth;
    }

    /// <summary>
    /// Inflict damage to the current attacker.
    /// </summary>
    /// <param name="amount">Amount of damage dealed</param>
    /// <returns>True if he died, false if he didn't</returns>
    public bool TakeDamage(int amount)
    {
        currentHealth -= amount;
        UpdateHealthBar();
        if (currentHealth <= 0)
        {
            FindObjectOfType<CoreGame>().AddBonesByKill(boneValue);
            Destroy(this.gameObject);
            GameObject deathAnim = Instantiate(DeathAnimation, transform.position, Quaternion.identity) as GameObject;
            Destroy(deathAnim, 1f);
            return true;
        }
        else
            return false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(currentDirection * currentSpeed * Time.deltaTime);
    }

    public void SetDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.up:
                currentDirection = Vector2.up;
                break;
            case Direction.left:
                currentDirection = Vector2.left;
                break;
            case Direction.right:
                currentDirection = Vector2.right;
                break;
            case Direction.down:
                currentDirection = Vector2.down;
                break;
            default:
                break;
        }
    }
}
