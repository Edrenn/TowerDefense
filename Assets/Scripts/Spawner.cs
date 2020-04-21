using Assets.Scripts.enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    #region Time
    [SerializeField] Slider waveTimer;
    [SerializeField] GameObject timerUI;
    public float timeBetweenWaves;
    public float currentTime;
    #endregion


    [SerializeField] Direction spawnDirection;
    [SerializeField] GameObject attackerPrefab;
    [SerializeField] Queue<Wave> allWaves;
    public bool isSpawning = true;
    public bool waitingForWave = false;

    public int TEMP_timeBetweenSpawn;

    private CoreGame currentLevelData;
    private GameObject spawnerParent;

    private void Awake()
    {
        currentLevelData = FindObjectOfType<CoreGame>();
        waveTimer.maxValue = timeBetweenWaves;
        allWaves = new Queue<Wave>();
        Wave wave1 = new Wave() { enemyType = AttackerEnum.Knight , nbEnemy = 5 };
        allWaves.Enqueue(wave1);
        Wave wave2 = new Wave() { enemyType = AttackerEnum.Ranger, nbEnemy = 5 };
        allWaves.Enqueue(wave2);
        Wave wave3 = new Wave() { enemyType = AttackerEnum.Knight, nbEnemy = 10 };
        allWaves.Enqueue(wave3);
        Wave wave4 = new Wave() { enemyType = AttackerEnum.Ranger, nbEnemy = 15 };
        allWaves.Enqueue(wave4);
    }

    private void Start()
    {
        spawnerParent = GameObject.Find(CoreGame.ATTACKER_PARENT_GAMEOBJECT);
        if (spawnerParent == null)
        {
            spawnerParent = new GameObject(CoreGame.ATTACKER_PARENT_GAMEOBJECT);
        }
        timerUI.SetActive(false);
        if (allWaves.Count > 0 && isSpawning)
            StartCoroutine(StartSpawn());
    }

    private void Update()
    {
        if (waitingForWave)
        {
            currentTime = currentTime - Time.deltaTime;
            if (currentTime <= 0)
            {
                LaunchNextWave();
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
            int spawnCount = 0;
            while (spawnCount < currentW.nbEnemy)
            {
                Attacker newAttacker = currentLevelData.FindAttacker((AttackerEnum)currentW.enemyType);
                if (newAttacker)
                {
                    Spawn(newAttacker);
                }
                spawnCount++;
                yield return new WaitForSeconds(TEMP_timeBetweenSpawn);
            }
            if (allWaves.Count > 0)
            {
                LaunchTimer();
                yield return new WaitUntil(() => currentTime <= 0);
            }
            else
            {
                FindObjectOfType<CoreGame>().SpawnerFinishedCall(this);
            }
        }
    }

    public void LaunchWaveBeforeTimer()
    {
        CoreGame coreGame = FindObjectOfType<CoreGame>();
        if (coreGame)
        {
            coreGame.AddBones(Mathf.RoundToInt(currentTime * 2));
        }
        LaunchNextWave();
    }

    private void LaunchNextWave()
    {
        currentTime = 0;
        waitingForWave = false;
        timerUI.SetActive(false);
    }

    private void LaunchTimer()
    {
        currentTime = timeBetweenWaves;
        waitingForWave = true;
        timerUI.SetActive(true);
        Debug.Log("Wait "+ timeBetweenWaves+"s before next Wave");
    }

    private void Spawn(Attacker attacker)
    {
        Attacker spawnedAttacker = Instantiate(attacker, transform.position, Quaternion.identity) as Attacker;
        spawnedAttacker.SetDirection(spawnDirection);
        spawnedAttacker.transform.SetParent(spawnerParent.transform);
    }

}
