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

    private LevelData currentLevelData;
    private GameObject spawnerParent;

    private void Awake()
    {
        currentLevelData = FindObjectOfType<LevelData>();
        waveTimer.maxValue = timeBetweenWaves;
        allWaves = new Queue<Wave>();
        Wave wave1 = new Wave() { allAttackers = new Queue<Attacker>(), allAttackersEnum = new Queue<AttackerEnum>() };
        wave1.allAttackersEnum.Enqueue(AttackerEnum.Ranger);
        wave1.allAttackersEnum.Enqueue(AttackerEnum.Ranger);
        //wave1.allAttackers.Enqueue(attackerPrefab.GetComponent<Attacker>());
        //wave1.allAttackers.Enqueue(attackerPrefab.GetComponent<Attacker>());
        //wave1.allAttackers.Enqueue(attackerPrefab.GetComponent<Attacker>());
        allWaves.Enqueue(wave1);
        //Wave wave2 = new Wave() { allAttackers = new Queue<Attacker>() };
        //wave2.allAttackers.Enqueue(attackerPrefab.GetComponent<Attacker>());
        //allWaves.Enqueue(wave2);
    }

    private void Start()
    {

        spawnerParent = GameObject.Find(LevelData.ATTACKER_PARENT_GAMEOBJECT);
        if (spawnerParent == null)
        {
            spawnerParent = new GameObject(LevelData.ATTACKER_PARENT_GAMEOBJECT);
        }
        waveTimer.gameObject.SetActive(false);
        if (allWaves.Count > 0)
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
            Debug.Log("New Wave : " + currentW.allAttackers.Count + " ennemies.");

            while (currentW.allAttackersEnum.Count > 0)
            {
                AttackerEnum newAttackerName = currentW.allAttackersEnum.Dequeue();
                Debug.Log(newAttackerName.ToString());
                Attacker newAttacker = currentLevelData.FindAttacker(newAttackerName);
                if (newAttacker)
                {
                    Spawn(newAttacker);
                }
                yield return new WaitForSeconds(TEMP_timeBetweenSpawn);
            }
            if (allWaves.Count > 0)
            {
                LaunchTimer();
                yield return new WaitForSeconds(timeBetweenWaves);
            }
            else
            {
                FindObjectOfType<CoreGame>().SpawnerFinishedCall(this);
            }
        }
    }

    private void LaunchTimer()
    {
        currentTime = timeBetweenWaves;
        waitingForWave = true;
        waveTimer.gameObject.SetActive(true);
        Debug.Log("Wait "+ timeBetweenWaves+"s before next Wave");
    }

    private void Spawn(Attacker attacker)
    {
        Attacker spawnedAttacker = Instantiate(attacker, transform.position, Quaternion.identity) as Attacker;
        spawnedAttacker.SetDirection(spawnDirection);
        spawnedAttacker.transform.SetParent(spawnerParent.transform);
    }

}
