using Assets.Scripts.enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelData
{
    public const string DATAKEY = "Levels"; 

    public int Id;
    public bool isUnlocked { get; set; }
    public bool upgradePointAvailable { get; set; } = true;
    public int currentScore { get; set; }
    public int Index { get; set; }

    public List<Wave> Waves { get; set; }
}
