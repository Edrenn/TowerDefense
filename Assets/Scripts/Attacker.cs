using Assets.Scripts.enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 4;
    Vector2 currentDirection = Vector2.down;
    [SerializeField] float speed = 1f;
    [SerializeField] int boneValue = 10;
    [SerializeField] private GameObject DeathAnimation;
    public void SetMovementSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            FindObjectOfType<CoreGame>().AddBones(boneValue);
            Destroy(this.gameObject);
            GameObject deathAnim = Instantiate(DeathAnimation, transform.position, Quaternion.identity) as GameObject;
            Destroy(deathAnim, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(currentDirection * speed * Time.deltaTime);
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
