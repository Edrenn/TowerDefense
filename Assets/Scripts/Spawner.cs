using Assets.Scripts.enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    #region Time
    [SerializeField] Slider waveTimer;
    public float timeBetweenWaves;
    public float currentTime;
    #endregion


    [SerializeField] Direction spawnDirection;
    [SerializeField] GameObject attackerPrefab;
    [SerializeField] Queue<Wave> allWaves;
    public bool isSpawning = true;
    public bool waitingForWave = false;

    public int TEMP_nbenemySpawn;
    public int TEMP_timeBetweenSpawn;

    private void Awake()
    {
        waveTimer.maxValue = timeBetweenWaves;
        allWaves = new Queue<Wave>();
        allWaves.Enqueue(new Wave() { name = "1", nbEnemy = 1 });
        allWaves.Enqueue(new Wave() { name = "2", nbEnemy = 2 });
        allWaves.Enqueue(new Wave() { name = "3", nbEnemy = 3 });
        allWaves.Enqueue(new Wave() { name = "4", nbEnemy = 4 });
        allWaves.Enqueue(new Wave() { name = "5", nbEnemy = 5 });
    }

    private void Start()
    {
        waveTimer.gameObject.SetActive(false);
        StartCoroutine(StartSpawn());
    }

    private void Update()
    {
        if (waitingForWave)
        {
            currentTime = currentTime - Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = 0;
                waitingForWave = false;
                waveTimer.gameObject.SetActive(false);
            }
            waveTimer.value = currentTime;
        }
    }
    IEnumerator StartSpawn()
    {
        Debug.Log("Start spawning");
        while (allWaves.Count > 0)
        {
            Wave currentW = allWaves.Dequeue();
            Debug.Log("New Wave : " + currentW.name + " : " + currentW.nbEnemy + " ennemies.");
            isSpawning = true;

            int count = 0;
            while (isSpawning)
            {
                Spawn();
                yield return new WaitForSeconds(TEMP_timeBetweenSpawn);
                count++;
                if (count >= currentW.nbEnemy) isSpawning = false;
            }
            currentTime = timeBetweenWaves;
            waitingForWave = true;
            waveTimer.gameObject.SetActive(true);
            Debug.Log("Wait 5 s before next Wave");
            yield return new WaitForSeconds(5);
        }
    }

    private void Spawn()
    {
        GameObject spawnedAttacker = Instantiate(attackerPrefab, transform.position, Quaternion.identity) as GameObject;
        spawnedAttacker.GetComponent<Attacker>().SetDirection(spawnDirection);
    }

}
