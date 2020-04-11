using Assets.Scripts.enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public const string ATTACKER_PARENT_GAMEOBJECT = "ATTACKERPARENT";
    [SerializeField] public List<Attacker> allAvailableAttackers;
    private Dictionary<AttackerEnum, Attacker> allAvailableAttackersDictionary;

    private void Awake()
    {
        allAvailableAttackersDictionary = new Dictionary<AttackerEnum, Attacker>();
        foreach (var att in allAvailableAttackers)
        {
            allAvailableAttackersDictionary.Add(att.enumName, att);
        }
    }

    public Attacker FindAttacker(AttackerEnum attackerName)
    {
        if (allAvailableAttackersDictionary.ContainsKey(attackerName))
        {
            return allAvailableAttackersDictionary[attackerName];
        }
        else
            return null;
    }
}
