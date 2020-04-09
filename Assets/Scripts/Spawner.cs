using Assets.Scripts.enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Direction spawnDirection;
    [SerializeField] GameObject attackerPrefab;
    public bool isSpawning = true;

    private void Start()
    {
        StartCoroutine(StartSpawn());
    }

    IEnumerator StartSpawn()
    {
        Debug.Log("Start spawning");
        int count = 0;
        while (isSpawning)
        {
            Spawn();
            yield return new WaitForSeconds(2);
            count++;
            if (count > 2) isSpawning = false;
        }
    }

    private void Spawn()
    {
        GameObject spawnedAttacker = Instantiate(attackerPrefab, transform.position, Quaternion.identity) as GameObject;
        spawnedAttacker.GetComponent<Attacker>().SetDirection(spawnDirection);
    }

}
