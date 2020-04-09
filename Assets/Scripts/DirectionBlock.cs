using Assets.Scripts.enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionBlock : MonoBehaviour
{

    [SerializeField] Direction direction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker attacker = collision.GetComponent<Attacker>();
        if (attacker)
        {
            attacker.SetDirection(direction);
        }
        
    }
}
