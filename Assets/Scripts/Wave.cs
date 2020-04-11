using Assets.Scripts.enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public int nbEnemy;

    public Queue<Attacker> allAttackers;
    public Queue<AttackerEnum> allAttackersEnum;
}
