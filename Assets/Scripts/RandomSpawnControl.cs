using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnControl : MonoBehaviour
{
    public GameObject[] enemySpawnerGO;
    public GameObject mapGOParent;
    public GameObject spawnParentGO;

    // Start is called before the first frame update
    void Start()
    {
        spawnParentGO = GameObject.FindWithTag("MapGOTagger");

        GameObject goInstantiated;
        GameObject objToSpawn = enemySpawnerGO[Random.Range((int)0, enemySpawnerGO.Length)];
        goInstantiated = Instantiate(objToSpawn, this.transform.position, this.transform.rotation);
        goInstantiated.transform.SetParent(spawnParentGO.transform);

        Destroy(this.gameObject);
    }
}
