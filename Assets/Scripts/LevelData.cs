﻿using Assets.Scripts.enums;
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
    public int currentStars { get; set; }
    public int Index { get; set; }

    public List<Wave> Waves { get; set; }
}
