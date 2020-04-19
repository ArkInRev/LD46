using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPositionControl : MonoBehaviour
{
    private GameObject playerGO;
    private GameObject playerSpawnGO;

    // Start is called before the first frame update
    void Start()
    {
        playerSpawnGO = GameObject.FindGameObjectWithTag("Respawn");
        playerGO = GameObject.FindGameObjectWithTag("Player");

        playerSpawnGO.transform.position = this.transform.position;
        playerGO.transform.position = playerSpawnGO.GetComponent<PlayerSpawner>().playerSpawnLocation.position;

        Destroy(this.gameObject);
    }


}
