using Assets.Scripts.enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Wave
{
    public int Id;

    public int nbEnemy;

    public AttackerEnum enemyType;

    public float timeBetweenSpawn = 1;
}
