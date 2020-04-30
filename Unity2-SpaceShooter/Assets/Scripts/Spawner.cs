using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject toSpawn;

    public float spawnTime = 1f;
    public float tillNextSpawn =0 ;
    public float spawnRange = 5f;

    public float initialDelay = 0;
    private float delayTimeLeft = 0;

    private bool spawnerIsReady = false;
    public int numberOfSpawns = -1;
    private int spawnsLeft= 0;
    public bool isLooping = true;

    public bool stopSpawningOnBoss = true;
    private int bossesInGame = 0;
 
    void Start()
    {
        tillNextSpawn = spawnTime;
        SetSpawnDelay();
    }

    void SetSpawnDelay()
    {
        spawnerIsReady = false;
        if (initialDelay > 0)
        {
            //Invoke("SetSpawnReady", initialDelay);
            delayTimeLeft = initialDelay;
        }
        else
        {
            SetSpawnReady();
        }
    }
    void SetSpawnReady()
    {
        spawnerIsReady = true;
        spawnsLeft = numberOfSpawns;
    }

	// Update is called once per frame
	void Update () {

        if (stopSpawningOnBoss && bossesInGame > 0)
        {
            return;
        }

        if (!spawnerIsReady) // spawner == false
        {
            delayTimeLeft -= Time.deltaTime;
            if(delayTimeLeft <= 0)
            {
                SetSpawnDelay();
            }
            return;
        }

        if (spawnsLeft <= 0 && numberOfSpawns > 0)
        {
            //if looping call delay to reset else destroy
            if (isLooping)
            {
                SetSpawnDelay();
            }
            else
            {
                Destroy(gameObject);
            }
            return;
        }

        tillNextSpawn -= Time.deltaTime;
        if(tillNextSpawn <= 0)
        {
            Spawn();
            tillNextSpawn = spawnTime;
        }
	}

    void Spawn()
    {
        Vector3 spawnPos = transform.position;
        spawnPos.x += Random.Range(-spawnRange, spawnRange);
        Instantiate(toSpawn, spawnPos, transform.rotation); //transform : position, scale, rotation

        spawnsLeft--;
    }

    public void OnBossSpawned()
    {
        bossesInGame++;
    }

    public void OnBossKilled()
    {
        bossesInGame--;
    }
}
