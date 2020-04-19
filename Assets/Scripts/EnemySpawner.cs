using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour, ISpawner
{
    private GameManager gm;
    public GameObject enemyPrefab;
    public Transform enemySpawnLocation;
    public GameObject spawnParentGO;
    GameObject goInstantiated;

    public float timeBetweenSpawnsMin = 5;
    public float timeBetweenSpawnsMax = 10;
    public float timeUntilNextSpawn = 5;
    public float timeSinceLastSpawn = 0;
 ///   private PlayerController pc;

    public void Spawn(GameObject go, Transform spawnAt)
    {
        goInstantiated = Instantiate(go, spawnAt.position, spawnAt.rotation);
        goInstantiated.transform.SetParent(spawnParentGO.transform);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
        spawnParentGO = GameObject.FindWithTag("MapGOTagger");
        //       gm.onPlayerKilled += OnPlayerKilled;
        //        Spawn(player, playerSpawnLocation);
    }

    void FixedUpdate()
    {
        timeSinceLastSpawn += Time.fixedDeltaTime;
        if (timeSinceLastSpawn >= timeUntilNextSpawn)
        {
            Spawn(enemyPrefab, enemySpawnLocation);
            timeUntilNextSpawn = Random.Range(timeBetweenSpawnsMin, timeBetweenSpawnsMax);
            timeSinceLastSpawn = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
    }
}
