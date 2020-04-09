using Assets.Scripts.enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Direction spawnDirection;
    [SerializeField] GameObject attackerPrefab;
    public bool isSpawning = true;

    public int TEMP_nbenemySpawn;
    public int TEMP_timeBetweenSpawn;

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
            yield return new WaitForSeconds(TEMP_timeBetweenSpawn);
            count++;
            if (count > TEMP_nbenemySpawn) isSpawning = false;
        }
    }

    private void Spawn()
    {
        GameObject spawnedAttacker = Instantiate(attackerPrefab, transform.position, Quaternion.identity) as GameObject;
        spawnedAttacker.GetComponent<Attacker>().SetDirection(spawnDirection);
    }

}
